using Microsoft.Win32;
using MileXamlBlankAppNetCoreModern.WindowsAPI.PInvoke.Comctl32;
using MileXamlBlankAppNetCoreModern.WindowsAPI.PInvoke.Kernel32;
using MileXamlBlankAppNetCoreModern.WindowsAPI.PInvoke.User32;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Composition.Desktop;
using Windows.UI.Xaml;

namespace MileXamlBlankAppNetCoreModern.UI.Backdrop
{
    public sealed partial class MicaBackdrop : SystemBackdrop
    {
        private const int PBT_POWERSETTINGCHANGE = 0x8013;

        private bool isInitialized;
        private bool isFormClosed;
        private bool isEnergySaverEnabled;
        private bool isActivated = true;
        private bool useMicaBrush;

        private IntPtr hPowerNotify;
        private Guid GUID_POWER_SAVING_STATUS = new("E00958C0-C213-4ACE-AC77-FECCED2EEEA5");

        private readonly Form formRoot;
        private readonly FrameworkElement rootElement;
        private readonly CompositionCapabilities compositionCapabilities = CompositionCapabilities.GetForCurrentView();
        private readonly SynchronizationContext synchronizationContext = SynchronizationContext.Current;

        private readonly float defaultMicaBaseLightTintOpacity = 0.5f;
        private readonly float defaultMicaBaseLightLuminosityOpacity = 1;
        private readonly float defaultMicaBaseDarkTintOpacity = 0.8f;
        private readonly float defaultMicaBaseDarkLuminosityOpacity = 1;
        private readonly Color defaultMicaBaseLightTintColor = Color.FromArgb(255, 243, 243, 243);
        private readonly Color defaultMicaBaseLightFallbackColor = Color.FromArgb(255, 243, 243, 243);
        private readonly Color defaultMicaBaseDarkTintColor = Color.FromArgb(255, 32, 32, 32);
        private readonly Color defaultMicaBaseDarkFallbackColor = Color.FromArgb(255, 32, 32, 32);

        private readonly float defaultMicaAltLightTintOpacity = 0.5f;
        private readonly float defaultMicaAltLightLuminosityOpacity = 1;
        private readonly float defaultMicaAltDarkTintOpacity = 0;
        private readonly float defaultMicaAltDarkLuminosityOpacity = 1;
        private readonly Color defaultMicaAltLightTintColor = Color.FromArgb(255, 218, 218, 218);
        private readonly Color defaultMicaAltLightFallbackColor = Color.FromArgb(255, 218, 218, 218);
        private readonly Color defaultMicaAltDarkTintColor = Color.FromArgb(255, 10, 10, 10);
        private readonly Color defaultMicaAltDarkFallbackColor = Color.FromArgb(255, 10, 10, 10);

        private SUBCLASSPROC formSubClassProc;

        public MicaKind Kind { get; set; } = MicaKind.Base;

        private float _lightTintOpacity = 0;

        public override float LightTintOpacity
        {
            get { return _lightTintOpacity; }

            set
            {
                if (!Equals(_lightTintOpacity, value))
                {
                    _lightTintOpacity = value;
                    if (value < 0 || value > 1)
                    {
                        throw new ArgumentException("值必须在 0 到 1 之间");
                    }

                    UpdateBrush();
                }
            }
        }

        private float _lightLuminosityOpacity = 0;

        public override float LightLuminosityOpacity
        {
            get { return _lightLuminosityOpacity; }

            set
            {
                if (!Equals(_lightLuminosityOpacity, value))
                {
                    _lightLuminosityOpacity = value;
                    if (value < 0 || value > 1)
                    {
                        throw new ArgumentException("值必须在 0 到 1 之间");
                    }

                    UpdateBrush();
                }
            }
        }

        private float _darkTintOpacity = 0;

        public override float DarkTintOpacity
        {
            get { return _darkTintOpacity; }

            set
            {
                if (!Equals(_darkTintOpacity, value))
                {
                    _darkTintOpacity = value;
                    if (value < 0 || value > 1)
                    {
                        throw new ArgumentException("值必须在 0 到 1 之间");
                    }

                    UpdateBrush();
                }
            }
        }

        private float _darkLuminosityOpacity = 0;

        public override float DarkLuminosityOpacity
        {
            get { return _darkLuminosityOpacity; }

            set
            {
                if (!Equals(_darkLuminosityOpacity, value))
                {
                    _darkLuminosityOpacity = value;
                    if (value < 0 || value > 1)
                    {
                        throw new ArgumentException("值必须在 0 到 1 之间");
                    }

                    UpdateBrush();
                }
            }
        }

        private Color _lightTintColor = Color.FromArgb(0, 0, 0, 0);

        public override Color LightTintColor
        {
            get { return _lightTintColor; }

            set
            {
                if (!Equals(_lightTintColor, value))
                {
                    _lightTintColor = value;
                    UpdateBrush();
                }
            }
        }

        private Color _lightFallbackColor = Color.FromArgb(0, 0, 0, 0);

        public override Color LightFallbackColor
        {
            get { return _lightFallbackColor; }

            set
            {
                if (!Equals(_lightFallbackColor, value))
                {
                    _lightFallbackColor = value;
                    UpdateBrush();
                }
            }
        }

        private Color _darkTintColor = Color.FromArgb(0, 0, 0, 0);

        public override Color DarkTintColor
        {
            get { return _darkTintColor; }

            set
            {
                if (!Equals(_darkTintColor, value))
                {
                    _darkTintColor = value;
                    UpdateBrush();
                }
            }
        }

        private Color _darkFallbackColor = Color.FromArgb(0, 0, 0, 0);

        public override Color DarkFallbackColor
        {
            get { return _darkFallbackColor; }

            set
            {
                if (!Equals(_darkFallbackColor, value))
                {
                    _darkFallbackColor = value;
                    UpdateBrush();
                }
            }
        }

        private ElementTheme _requestedTheme = ElementTheme.Default;

        public override ElementTheme RequestedTheme
        {
            get { return _requestedTheme; }

            set
            {
                if (!Equals(_requestedTheme, value))
                {
                    _requestedTheme = value;
                    UpdateBrush();
                }
            }
        }

        private bool _isInputActive = false;

        public override bool IsInputActive
        {
            get { return _isInputActive; }

            set
            {
                if (!Equals(_isInputActive, value))
                {
                    _isInputActive = value;
                }
            }
        }

        public static bool IsSupported
        {
            get { return Environment.OSVersion.Version >= new Version(10, 0, 22000, 0); }
        }

        public MicaBackdrop(DesktopWindowTarget target, FrameworkElement element, Form form) : base(target)
        {
            if (target is null)
            {
                throw new ArgumentNullException(string.Format("参数 {0} 不可以为空值", nameof(target)));
            }

            if (form is null)
            {
                throw new ArgumentNullException(string.Format("参数 {0} 不可以为空值", nameof(element)));
            }

            formRoot = form;
            rootElement = element;
        }

        ~MicaBackdrop()
        {
            Dispose(false);
        }

        public override void InitializeBackdrop()
        {
            if (!isInitialized)
            {
                float defaultOpacityValue = 0;
                Color defaultColorValue = Color.FromArgb(0, 0, 0, 0);

                if (Kind is MicaKind.Base)
                {
                    _lightTintOpacity = _lightTintOpacity.Equals(defaultOpacityValue) ? defaultMicaBaseLightTintOpacity : _lightTintOpacity;
                    _lightLuminosityOpacity = _lightLuminosityOpacity.Equals(defaultOpacityValue) ? defaultMicaBaseLightLuminosityOpacity : _lightLuminosityOpacity;
                    _darkTintOpacity = _darkTintOpacity.Equals(defaultOpacityValue) ? defaultMicaBaseDarkTintOpacity : _darkTintOpacity;
                    _darkLuminosityOpacity = _darkLuminosityOpacity.Equals(defaultOpacityValue) ? defaultMicaBaseDarkLuminosityOpacity : _darkLuminosityOpacity;
                    _lightTintColor = _lightTintColor.Equals(defaultColorValue) ? defaultMicaBaseLightTintColor : _lightTintColor;
                    _lightFallbackColor = _lightFallbackColor.Equals(defaultColorValue) ? defaultMicaBaseLightFallbackColor : _lightFallbackColor;
                    _darkTintColor = _darkTintColor.Equals(defaultColorValue) ? defaultMicaBaseDarkTintColor : _darkTintColor;
                    _darkFallbackColor = _darkFallbackColor.Equals(defaultColorValue) ? defaultMicaBaseDarkFallbackColor : _darkFallbackColor;
                }
                else
                {
                    _lightTintOpacity = _lightTintOpacity.Equals(defaultOpacityValue) ? defaultMicaAltLightTintOpacity : _lightTintOpacity;
                    _lightLuminosityOpacity = _lightLuminosityOpacity.Equals(defaultOpacityValue) ? defaultMicaAltLightLuminosityOpacity : _lightLuminosityOpacity;
                    _darkTintOpacity = _darkTintOpacity.Equals(defaultOpacityValue) ? defaultMicaAltDarkTintOpacity : _darkTintOpacity;
                    _darkLuminosityOpacity = _darkLuminosityOpacity.Equals(defaultOpacityValue) ? defaultMicaAltDarkLuminosityOpacity : _darkLuminosityOpacity;
                    _lightTintColor = _lightTintColor.Equals(defaultColorValue) ? defaultMicaAltLightTintColor : _lightTintColor;
                    _lightFallbackColor = _lightFallbackColor.Equals(defaultColorValue) ? defaultMicaAltLightFallbackColor : _lightFallbackColor;
                    _darkTintColor = _darkTintColor.Equals(defaultColorValue) ? defaultMicaAltDarkTintColor : _darkTintColor;
                    _darkFallbackColor = _darkFallbackColor.Equals(defaultColorValue) ? defaultMicaAltDarkFallbackColor : _darkFallbackColor;
                }

                if (DesktopWindowTarget.Root is null)
                {
                    DesktopWindowTarget.Root = DesktopWindowTarget.Compositor.CreateSpriteVisual();
                }

                SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
                formRoot.SizeChanged += OnSizeChanged;
                formRoot.DpiChanged += OnDpiChanged;
                formRoot.FormClosed += OnFormClosed;
                formRoot.Activated += OnActivated;
                formRoot.Deactivate += OnDeactivated;
                compositionCapabilities.Changed += OnCompositionCapabilitiesChanged;

                if (rootElement is not null)
                {
                    rootElement.ActualThemeChanged += OnActualThemeChanged;
                }

                formSubClassProc = new SUBCLASSPROC(OnFormSubClassProc);
                Comctl32Library.SetWindowSubclass(formRoot.Handle, Marshal.GetFunctionPointerForDelegate(formSubClassProc), 0, IntPtr.Zero);

                IntPtr hPowerNotify = User32Library.RegisterPowerSettingNotification(formRoot.Handle, ref GUID_POWER_SAVING_STATUS, 0);

                isInitialized = true;

                UpdateBrush();
            }
        }

        public override void ResetProperties()
        {
            if (Kind is MicaKind.Base)
            {
                _lightTintOpacity = defaultMicaBaseLightTintOpacity;
                _lightLuminosityOpacity = defaultMicaBaseLightLuminosityOpacity;
                _darkTintOpacity = defaultMicaBaseDarkTintOpacity;
                _darkLuminosityOpacity = defaultMicaBaseDarkLuminosityOpacity;
                _lightTintColor = defaultMicaBaseLightTintColor;
                _lightFallbackColor = defaultMicaBaseLightFallbackColor;
                _darkTintColor = defaultMicaBaseDarkTintColor;
                _darkFallbackColor = defaultMicaBaseDarkFallbackColor;
            }
            else
            {
                _lightTintOpacity = defaultMicaAltLightTintOpacity;
                _lightLuminosityOpacity = defaultMicaAltLightLuminosityOpacity;
                _darkTintOpacity = defaultMicaAltDarkTintOpacity;
                _darkLuminosityOpacity = defaultMicaAltDarkLuminosityOpacity;
                _lightTintColor = defaultMicaAltLightTintColor;
                _lightFallbackColor = defaultMicaAltLightFallbackColor;
                _darkTintColor = defaultMicaAltDarkTintColor;
                _darkFallbackColor = defaultMicaAltDarkFallbackColor;
            }

            _requestedTheme = ElementTheme.Default;
            _isInputActive = false;

            if (isInitialized)
            {
                UpdateBrush();
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            lock (this)
            {
                if (isInitialized)
                {
                    isInitialized = false;

                    SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
                    formRoot.SizeChanged -= OnSizeChanged;
                    formRoot.DpiChanged -= OnDpiChanged;
                    formRoot.FormClosed -= OnFormClosed;
                    formRoot.Activated -= OnActivated;
                    formRoot.Deactivate -= OnDeactivated;
                    compositionCapabilities.Changed -= OnCompositionCapabilitiesChanged;

                    if (rootElement is not null)
                    {
                        rootElement.ActualThemeChanged -= OnActualThemeChanged;
                    }

                    if (hPowerNotify != IntPtr.Zero)
                    {
                        User32Library.UnregisterPowerSettingNotification(hPowerNotify);
                        hPowerNotify = IntPtr.Zero;
                    }

                    Comctl32Library.RemoveWindowSubclass(formRoot.Handle, Marshal.GetFunctionPointerForDelegate(formSubClassProc), 0);

                    if (DesktopWindowTarget.Root is SpriteVisual spriteVisual && spriteVisual.Brush is not null)
                    {
                        spriteVisual.Brush.Dispose();
                        spriteVisual.Brush = null;
                    }
                }
            }
        }

        private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs args)
        {
            synchronizationContext.Post(_ =>
            {
                UpdateBrush();
            }, null);
        }

        private void OnSizeChanged(object sender, EventArgs args)
        {
            synchronizationContext.Post(_ =>
            {
                if (DesktopWindowTarget.Root is SpriteVisual spriteVisual)
                {
                    spriteVisual.Size = new Vector2(formRoot.Width, formRoot.Height);
                }
            }, null);
        }

        private void OnDpiChanged(object sender, DpiChangedEventArgs args)
        {
            synchronizationContext.Post(_ =>
            {
                if (DesktopWindowTarget.Root is SpriteVisual spriteVisual)
                {
                    spriteVisual.Size = new Vector2(formRoot.Width, formRoot.Height);
                }
            }, null);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs args)
        {
            if (!isFormClosed)
            {
                isFormClosed = true;
                Dispose();
            }
        }

        private void OnActivated(object sender, EventArgs args)
        {
            isActivated = true;
            UpdateBrush();
        }

        private void OnDeactivated(object sender, EventArgs args)
        {
            isActivated = false;
            UpdateBrush();
        }

        private void OnCompositionCapabilitiesChanged(CompositionCapabilities sender, object args)
        {
            synchronizationContext.Post(_ =>
            {
                UpdateBrush();
            }, null);
        }

        private void OnActualThemeChanged(FrameworkElement sender, object args)
        {
            UpdateBrush();
        }

        private void UpdateBrush()
        {
            if (isInitialized)
            {
                ElementTheme actualTheme = ElementTheme.Default;

                if (rootElement is not null)
                {
                    actualTheme = RequestedTheme is ElementTheme.Default ? rootElement.ActualTheme : RequestedTheme;
                }
                else
                {
                    actualTheme = Windows.UI.Xaml.Application.Current.RequestedTheme is ApplicationTheme.Light ? ElementTheme.Light : ElementTheme.Dark;
                }

                float tintOpacity;
                float luminosityOpacity;
                Color tintColor;
                Color fallbackColor;

                if (actualTheme is ElementTheme.Light)
                {
                    tintOpacity = LightTintOpacity;
                    luminosityOpacity = LightLuminosityOpacity;
                    tintColor = LightTintColor;
                    fallbackColor = LightFallbackColor;
                }
                else
                {
                    tintOpacity = DarkTintOpacity;
                    luminosityOpacity = DarkLuminosityOpacity;
                    tintColor = DarkTintColor;
                    fallbackColor = DarkFallbackColor;
                }

                useMicaBrush = IsSupported && IsAdvancedEffectsEnabled() && !isEnergySaverEnabled && compositionCapabilities.AreEffectsSupported() && (IsInputActive || isActivated);

                if (SystemInformation.HighContrast)
                {
                    System.Drawing.Color windowColor = System.Drawing.SystemColors.Window;
                    tintColor = Color.FromArgb(windowColor.R, windowColor.A, windowColor.G, windowColor.B); // new UISettings().GetColorValue(UIColorType.Background)
                    useMicaBrush = false;
                }

                Compositor compositor = DesktopWindowTarget.Compositor;

                CompositionBrush newBrush = useMicaBrush ? BuildMicaEffectBrush(compositor, tintColor, tintOpacity, luminosityOpacity) : compositor.CreateColorBrush(fallbackColor);
                CompositionBrush oldBrush = (DesktopWindowTarget.Root as SpriteVisual).Brush;

                if (oldBrush is null || oldBrush.Comment is "Crossfade")
                {
                    oldBrush?.Dispose();
                    (DesktopWindowTarget.Root as SpriteVisual).Brush = newBrush;
                    (DesktopWindowTarget.Root as SpriteVisual).Size = new(formRoot.Width, formRoot.Height);
                }
                else
                {
                    CompositionBrush crossFadeBrush = CreateCrossFadeEffectBrush(compositor, oldBrush, newBrush);
                    ScalarKeyFrameAnimation animation = CreateCrossFadeAnimation(compositor);
                    (DesktopWindowTarget.Root as SpriteVisual).Brush = crossFadeBrush;
                    (DesktopWindowTarget.Root as SpriteVisual).Size = new(formRoot.Width, formRoot.Height);

                    CompositionScopedBatch crossFadeAnimationBatch = compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
                    crossFadeBrush.StartAnimation("CrossFade.CrossFade", animation);
                    crossFadeAnimationBatch.End();

                    crossFadeAnimationBatch.Completed += (o, a) =>
                    {
                        crossFadeBrush.Dispose();
                        oldBrush.Dispose();
                        (DesktopWindowTarget.Root as SpriteVisual).Brush = newBrush;
                        (DesktopWindowTarget.Root as SpriteVisual).Size = new(formRoot.Width, formRoot.Height);
                    };
                }
            }
        }

        private CompositionEffectBrush BuildMicaEffectBrush(Compositor compositor, Color tintColor, float tintOpacity, float luminosityOpacity)
        {
            // Tint Color.
            ColorSourceEffect tintColorEffect = new()
            {
                Name = "TintColor",
                Color = tintColor
            };

            // OpacityEffect applied to Tint.
            OpacityEffect tintOpacityEffect = new()
            {
                Name = "TintOpacity",
                Opacity = tintOpacity,
                Source = tintColorEffect
            };

            // Apply Luminosity:

            // Luminosity Color.
            ColorSourceEffect luminosityColorEffect = new()
            {
                Color = tintColor
            };

            // OpacityEffect applied to Luminosity.
            OpacityEffect luminosityOpacityEffect = new()
            {
                Name = "LuminosityOpacity",
                Opacity = luminosityOpacity,
                Source = luminosityColorEffect
            };

            // Luminosity Blend.
            // NOTE: There is currently a bug where the names of BlendEffectMode::Luminosity and BlendEffectMode::Color are flipped.
            BlendEffect luminosityBlendEffect = new()
            {
                Mode = BlendEffectMode.Color,
                Background = new CompositionEffectSourceParameter("BlurredWallpaperBackdrop"),
                Foreground = luminosityOpacityEffect
            };

            // Apply Tint:

            // Color Blend.
            // NOTE: There is currently a bug where the names of BlendEffectMode::Luminosity and BlendEffectMode::Color are flipped.
            BlendEffect colorBlendEffect = new()
            {
                Mode = BlendEffectMode.Luminosity,
                Background = luminosityBlendEffect,
                Foreground = tintOpacityEffect
            };

            CompositionEffectBrush micaEffectBrush = compositor.CreateEffectFactory(colorBlendEffect).CreateBrush();
            micaEffectBrush.SetSourceParameter("BlurredWallpaperBackdrop", compositor.TryCreateBlurredWallpaperBackdropBrush());

            return micaEffectBrush;
        }

        private CompositionEffectBrush CreateCrossFadeEffectBrush(Compositor compositor, CompositionBrush from, CompositionBrush to)
        {
            CrossFadeEffect crossFadeEffect = new()
            {
                Name = "Crossfade", // Name to reference when starting the animation.
                Source1 = new CompositionEffectSourceParameter("source1"),
                Source2 = new CompositionEffectSourceParameter("source2"),
                CrossFade = 0
            };

            List<string> corssfadeList = ["Crossfade.CrossFade"];
            CompositionEffectBrush crossFadeEffectBrush = compositor.CreateEffectFactory(crossFadeEffect, corssfadeList).CreateBrush();
            crossFadeEffectBrush.Comment = "Crossfade";

            crossFadeEffectBrush.SetSourceParameter("source1", from);
            crossFadeEffectBrush.SetSourceParameter("source2", to);
            return crossFadeEffectBrush;
        }

        private ScalarKeyFrameAnimation CreateCrossFadeAnimation(Compositor compositor)
        {
            ScalarKeyFrameAnimation animation = compositor.CreateScalarKeyFrameAnimation();
            LinearEasingFunction linearEasing = compositor.CreateLinearEasingFunction();
            animation.InsertKeyFrame(0.0f, 0.0f, linearEasing);
            animation.InsertKeyFrame(1.0f, 1.0f, linearEasing);
            animation.Duration = TimeSpan.FromMilliseconds(250);
            return animation;
        }

        private IntPtr OnFormSubClassProc(IntPtr hWnd, WindowMessage Msg, UIntPtr wParam, IntPtr lParam, uint uIdSubclass, IntPtr dwRefData)
        {
            if (Msg is WindowMessage.WM_POWERBROADCAST && (int)wParam is PBT_POWERSETTINGCHANGE)
            {
                POWERBROADCAST_SETTING setting = Marshal.PtrToStructure<POWERBROADCAST_SETTING>(lParam);

                if (setting.PowerSetting == GUID_POWER_SAVING_STATUS)
                {
                    Kernel32Library.GetSystemPowerStatus(out SYSTEM_POWER_STATUS status);
                    isEnergySaverEnabled = Convert.ToBoolean(status.SystemStatusFlag);

                    if (isInitialized)
                    {
                        synchronizationContext.Post(_ =>
                        {
                            UpdateBrush();
                        }, null);
                    }
                }
            }

            return Comctl32Library.DefSubclassProc(hWnd, Msg, wParam, lParam);
        }
    }
}
