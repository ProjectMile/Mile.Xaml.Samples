﻿using Microsoft.Win32;
using MileXamlBlankAppNetFrameworkModern.WindowsAPI.PInvoke.Comctl32;
using MileXamlBlankAppNetFrameworkModern.WindowsAPI.PInvoke.Kernel32;
using MileXamlBlankAppNetFrameworkModern.WindowsAPI.PInvoke.User32;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Composition.Desktop;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace MileXamlBlankAppNetFrameworkModern.UI.Backdrop
{
    public class DesktopAcrylicBackdrop : SystemBackdrop
    {
        private const int PBT_POWERSETTINGCHANGE = 0x8013;

        private bool isInitialized;
        private bool isFormClosed;
        private bool isEnergySaverEnabled;
        private bool isActivated = true;
        private bool useDesktopAcrylicBrush;

        private IntPtr hPowerNotify;
        private Guid GUID_POWER_SAVING_STATUS = new("E00958C0-C213-4ACE-AC77-FECCED2EEEA5");

        private readonly Form formRoot;
        private readonly FrameworkElement rootElement;
        private readonly CompositionCapabilities compositionCapabilities = CompositionCapabilities.GetForCurrentView();

        private readonly float defaultDesktopAcrylicDefaultLightTintOpacity = 0;
        private readonly float defaultDesktopAcrylicDefaultLightLuminosityOpacity = 0.85f;
        private readonly float defaultDesktopAcrylicDefaultDarkTintOpacity = 0.15f;
        private readonly float defaultDesktopAcrylicDefaultDarkLuminosityOpacity = 96;
        private readonly Color defaultDesktopAcrylicDefaultLightTintColor = Color.FromArgb(255, 252, 252, 252);
        private readonly Color defaultDesktopAcrylicDefaultLightFallbackColor = Color.FromArgb(255, 249, 249, 249);
        private readonly Color defaultDesktopAcrylicDefaultDarkTintColor = Color.FromArgb(255, 44, 44, 44);
        private readonly Color defaultDesktopAcrylicDefaultDarkFallbackColor = Color.FromArgb(255, 44, 44, 44);

        private readonly float defaultDesktopAcrylicBaseLightTintOpacity = 0;
        private readonly float defaultDesktopAcrylicBaseLightLuminosityOpacity = 0.9f;
        private readonly float defaultDesktopAcrylicBaseDarkTintOpacity = 0.5f;
        private readonly float defaultDesktopAcrylicBaseDarkLuminosityOpacity = 0.96f;
        private readonly Color defaultDesktopAcrylicBaseLightTintColor = Color.FromArgb(255, 243, 243, 243);
        private readonly Color defaultDesktopAcrylicBaseLightFallbackColor = Color.FromArgb(255, 238, 238, 238);
        private readonly Color defaultDesktopAcrylicBaseDarkTintColor = Color.FromArgb(255, 32, 32, 32);
        private readonly Color defaultDesktopAcrylicBaseDarkFallbackColor = Color.FromArgb(255, 28, 28, 28);

        private readonly float defaultDesktopAcrylicThinLightTintOpacity = 0;
        private readonly float defaultDesktopAcrylicThinLightLuminosityOpacity = 0.44f;
        private readonly float defaultDesktopAcrylicThinDarkTintOpacity = 0.15f;
        private readonly float defaultDesktopAcrylicThinDarkLuminosityOpacity = 0.64f;
        private readonly Color defaultDesktopAcrylicThinLightTintColor = Color.FromArgb(255, 211, 211, 211);
        private readonly Color defaultDesktopAcrylicThinLightFallbackColor = Color.FromArgb(255, 211, 211, 211);
        private readonly Color defaultDesktopAcrylicThinDarkTintColor = Color.FromArgb(255, 84, 84, 84);
        private readonly Color defaultDesktopAcrylicThinDarkFallbackColor = Color.FromArgb(255, 84, 84, 84);

        private SUBCLASSPROC formSubClassProc;

        public DesktopAcrylicKind Kind { get; set; } = DesktopAcrylicKind.Default;

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
                        throw new ArgumentException("Value must between 0 to 1");
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
                        throw new ArgumentException("Value must between 0 to 1");
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
                        throw new ArgumentException("Value must between 0 to 1");
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
                        throw new ArgumentException("Value must between 0 to 1");
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

        private bool _useHostBackdropBrush = false;

        public bool UseHostBackdropBrush
        {
            get { return _useHostBackdropBrush; }

            set
            {
                if (!Equals(_useHostBackdropBrush, value))
                {
                    _useHostBackdropBrush = value;
                    UpdateBrush();
                }
            }
        }

        private float _blurAmount = 30f;

        public float BlurAmount
        {
            get { return _blurAmount; }

            set
            {
                if (!Equals(_blurAmount, value))
                {
                    _blurAmount = value;
                    UpdateBrush();
                }
            }
        }

        public override bool IsSupported
        {
            get
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Wallpaper");
                if (key is not null)
                {
                    object value = key.GetValue("WallpaperSurfaceProvidedToDwm");
                    if (value is not null && Convert.ToInt32(value) is 1)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool IsHostBackdropSupported
        {
            get { return Environment.OSVersion.Version >= new Version(10, 0, 22000, 0); }
        }

        public DesktopAcrylicBackdrop(DesktopWindowTarget target, FrameworkElement element, Form form) : base(target)
        {
            if (target is null)
            {
                throw new ArgumentNullException(string.Format("Parameter {0} can not be null", nameof(target)));
            }

            if (form is null)
            {
                throw new ArgumentNullException(string.Format("\"Parameter {0} can not be null", nameof(element)));
            }

            formRoot = form;
            rootElement = element;
        }

        public override void InitializeBackdrop()
        {
            if (!isInitialized)
            {
                float defaultOpacityValue = 0;
                Color defaultColorValue = Color.FromArgb(0, 0, 0, 0);

                if (Kind is DesktopAcrylicKind.Default)
                {
                    _lightTintOpacity = _lightTintOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicDefaultLightTintOpacity : _lightTintOpacity;
                    _lightLuminosityOpacity = _lightLuminosityOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicDefaultLightLuminosityOpacity : _lightLuminosityOpacity;
                    _darkTintOpacity = _darkTintOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicDefaultDarkTintOpacity : _darkTintOpacity;
                    _darkLuminosityOpacity = _darkLuminosityOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicDefaultDarkLuminosityOpacity : _darkLuminosityOpacity;
                    _lightTintColor = _lightTintColor.Equals(defaultColorValue) ? defaultDesktopAcrylicDefaultLightTintColor : _lightTintColor;
                    _lightFallbackColor = _lightFallbackColor.Equals(defaultColorValue) ? defaultDesktopAcrylicDefaultLightFallbackColor : _lightFallbackColor;
                    _darkTintColor = _darkTintColor.Equals(defaultColorValue) ? defaultDesktopAcrylicDefaultDarkTintColor : _darkTintColor;
                    _darkFallbackColor = _darkFallbackColor.Equals(defaultColorValue) ? defaultDesktopAcrylicDefaultDarkFallbackColor : _darkFallbackColor;
                }
                else if (Kind is DesktopAcrylicKind.Base)
                {
                    _lightTintOpacity = _lightTintOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicBaseLightTintOpacity : _lightTintOpacity;
                    _lightLuminosityOpacity = _lightLuminosityOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicBaseLightLuminosityOpacity : _lightLuminosityOpacity;
                    _darkTintOpacity = _darkTintOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicBaseDarkTintOpacity : _darkTintOpacity;
                    _darkLuminosityOpacity = _darkLuminosityOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicBaseDarkLuminosityOpacity : _darkLuminosityOpacity;
                    _lightTintColor = _lightTintColor.Equals(defaultColorValue) ? defaultDesktopAcrylicBaseLightTintColor : _lightTintColor;
                    _lightFallbackColor = _lightFallbackColor.Equals(defaultColorValue) ? defaultDesktopAcrylicBaseLightFallbackColor : _lightFallbackColor;
                    _darkTintColor = _darkTintColor.Equals(defaultColorValue) ? defaultDesktopAcrylicBaseDarkTintColor : _darkTintColor;
                    _darkFallbackColor = _darkFallbackColor.Equals(defaultColorValue) ? defaultDesktopAcrylicBaseDarkFallbackColor : _darkFallbackColor;
                }
                else
                {
                    _lightTintOpacity = _lightTintOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicThinLightTintOpacity : _lightTintOpacity;
                    _lightLuminosityOpacity = _lightLuminosityOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicThinLightLuminosityOpacity : _lightLuminosityOpacity;
                    _darkTintOpacity = _darkTintOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicThinDarkTintOpacity : _darkTintOpacity;
                    _darkLuminosityOpacity = _darkLuminosityOpacity.Equals(defaultOpacityValue) ? defaultDesktopAcrylicThinDarkLuminosityOpacity : _darkLuminosityOpacity;
                    _lightTintColor = _lightTintColor.Equals(defaultColorValue) ? defaultDesktopAcrylicThinLightTintColor : _lightTintColor;
                    _lightFallbackColor = _lightFallbackColor.Equals(defaultColorValue) ? defaultDesktopAcrylicThinLightFallbackColor : _lightFallbackColor;
                    _darkTintColor = _darkTintColor.Equals(defaultColorValue) ? defaultDesktopAcrylicThinDarkTintColor : _darkTintColor;
                    _darkFallbackColor = _darkFallbackColor.Equals(defaultColorValue) ? defaultDesktopAcrylicThinDarkFallbackColor : _darkFallbackColor;
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
                Comctl32Library.SetWindowSubclass(formRoot.Handle, formSubClassProc, 0, IntPtr.Zero);

                IntPtr hPowerNotify = User32Library.RegisterPowerSettingNotification(formRoot.Handle, ref GUID_POWER_SAVING_STATUS, 0);

                isInitialized = true;

                UpdateBrush();
            }
        }

        public override void ResetProperties()
        {
            if (Kind is DesktopAcrylicKind.Default)
            {
                _lightTintOpacity = defaultDesktopAcrylicDefaultLightTintOpacity;
                _lightLuminosityOpacity = defaultDesktopAcrylicDefaultLightLuminosityOpacity;
                _darkTintOpacity = defaultDesktopAcrylicDefaultDarkTintOpacity;
                _darkLuminosityOpacity = defaultDesktopAcrylicDefaultDarkLuminosityOpacity;
                _lightTintColor = defaultDesktopAcrylicDefaultLightTintColor;
                _lightFallbackColor = defaultDesktopAcrylicDefaultLightFallbackColor;
                _darkTintColor = defaultDesktopAcrylicDefaultDarkTintColor;
                _darkFallbackColor = defaultDesktopAcrylicDefaultDarkFallbackColor;
            }
            else if (Kind is DesktopAcrylicKind.Base)
            {
                _lightTintOpacity = defaultDesktopAcrylicBaseLightTintOpacity;
                _lightLuminosityOpacity = defaultDesktopAcrylicBaseLightLuminosityOpacity;
                _darkTintOpacity = defaultDesktopAcrylicBaseDarkTintOpacity;
                _darkLuminosityOpacity = defaultDesktopAcrylicBaseDarkLuminosityOpacity;
                _lightTintColor = defaultDesktopAcrylicBaseLightTintColor;
                _lightFallbackColor = defaultDesktopAcrylicBaseLightFallbackColor;
                _darkTintColor = defaultDesktopAcrylicBaseDarkTintColor;
                _darkFallbackColor = defaultDesktopAcrylicBaseDarkFallbackColor;
            }
            else
            {
                _lightTintOpacity = defaultDesktopAcrylicThinLightTintOpacity;
                _lightLuminosityOpacity = defaultDesktopAcrylicThinLightLuminosityOpacity;
                _darkTintOpacity = defaultDesktopAcrylicThinDarkTintOpacity;
                _darkLuminosityOpacity = defaultDesktopAcrylicThinDarkLuminosityOpacity;
                _lightTintColor = defaultDesktopAcrylicThinLightTintColor;
                _lightFallbackColor = defaultDesktopAcrylicThinLightFallbackColor;
                _darkTintColor = defaultDesktopAcrylicThinDarkTintColor;
                _darkFallbackColor = defaultDesktopAcrylicThinDarkFallbackColor;
            }

            _requestedTheme = ElementTheme.Default;
            _isInputActive = false;
            _useHostBackdropBrush = false;

            if (isInitialized)
            {
                UpdateBrush();
            }
        }

        public override void Dispose()
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

                if (DesktopWindowTarget.Root as SpriteVisual is not null && (DesktopWindowTarget.Root as SpriteVisual).Brush is not null)
                {
                    (DesktopWindowTarget.Root as SpriteVisual).Brush.Dispose();
                    (DesktopWindowTarget.Root as SpriteVisual).Brush = null;
                }
            }
        }

        private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs args)
        {
            formRoot.BeginInvoke(UpdateBrush);
        }

        private void OnSizeChanged(object sender, EventArgs args)
        {
            formRoot.BeginInvoke(() =>
            {
                SpriteVisual spriteVisual = DesktopWindowTarget.Root as SpriteVisual;
                if (spriteVisual is not null)
                {
                    spriteVisual.Size = new Vector2(formRoot.Width, formRoot.Height);
                }
            });
        }

        private void OnDpiChanged(object sender, DpiChangedEventArgs args)
        {
            formRoot.BeginInvoke(() =>
            {
                SpriteVisual spriteVisual = DesktopWindowTarget.Root as SpriteVisual;
                if (spriteVisual is not null)
                {
                    spriteVisual.Size = new Vector2(formRoot.Width, formRoot.Height);
                }
            });
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
            formRoot.BeginInvoke(UpdateBrush);
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

                useDesktopAcrylicBrush = IsSupported && IsAdvancedEffectsEnabled() && !isEnergySaverEnabled && compositionCapabilities.AreEffectsSupported() && (IsInputActive || isActivated);

                if (SystemInformation.HighContrast)
                {
                    System.Drawing.Color windowColor = System.Drawing.SystemColors.Window;
                    tintColor = Color.FromArgb(windowColor.R, windowColor.A, windowColor.G, windowColor.B); useDesktopAcrylicBrush = false;
                }

                Compositor compositor = DesktopWindowTarget.Compositor;

                CompositionBrush newBrush = useDesktopAcrylicBrush ? BuildDesktopAcrylicEffectBrush(compositor, tintColor, tintOpacity, luminosityOpacity) : compositor.CreateColorBrush(fallbackColor);

                CompositionBrush oldBrush = (DesktopWindowTarget.Root as SpriteVisual).Brush;

                if (oldBrush is null || oldBrush.Comment is "Crossfade")
                {
                    oldBrush?.Dispose();
                    (DesktopWindowTarget.Root as SpriteVisual).Brush = newBrush;
                    (DesktopWindowTarget.Root as SpriteVisual).Size = new Vector2(formRoot.Width, formRoot.Height);
                }
                else
                {
                    CompositionBrush crossFadeBrush = CreateCrossFadeEffectBrush(compositor, oldBrush, newBrush);
                    ScalarKeyFrameAnimation animation = CreateCrossFadeAnimation(compositor);
                    (DesktopWindowTarget.Root as SpriteVisual).Brush = crossFadeBrush;
                    (DesktopWindowTarget.Root as SpriteVisual).Size = new Vector2(formRoot.Width, formRoot.Height);

                    CompositionScopedBatch crossFadeAnimationBatch = compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
                    crossFadeBrush.StartAnimation("CrossFade.CrossFade", animation);
                    crossFadeAnimationBatch.End();

                    crossFadeAnimationBatch.Completed += (o, a) =>
                    {
                        crossFadeBrush.Dispose();
                        oldBrush.Dispose();
                        (DesktopWindowTarget.Root as SpriteVisual).Brush = newBrush;
                        (DesktopWindowTarget.Root as SpriteVisual).Size = new Vector2(formRoot.Width, formRoot.Height);
                    };
                }
            }
        }

        private CompositionBrush BuildDesktopAcrylicEffectBrush(Compositor compositor, Color tintColor, float tintOpacity, float luminosityOpacity)
        {
            Color convertedLuminosityColor = ColorConversion.GetEffectiveLuminosityColor(tintColor, tintOpacity, luminosityOpacity);
            Color convertedTintColor = ColorConversion.GetEffectiveTintColor(tintColor, tintOpacity, luminosityOpacity);

            ColorSourceEffect hostBackdropEffect = new()
            {
                Color = Color.FromArgb(255, 0, 0, 0)
            };

            OpacityEffect hostBackdropLayerEffect = new()
            {
                Name = "FixHostBackdropLayer",
                Opacity = IsHostBackdropSupported && UseHostBackdropBrush ? 1 : 0,
                Source = hostBackdropEffect,
            };

            GaussianBlurEffect gaussianBlurEffect = new()
            {
                Name = "GaussianBlurEffect",
                BlurAmount = IsHostBackdropSupported && UseHostBackdropBrush ? Math.Max(BlurAmount - 30, 0) : BlurAmount,
                Source = new CompositionEffectSourceParameter("source"),
                BorderMode = EffectBorderMode.Hard
            };

            BlendEffect luminosityColorEffect = new()
            {
                Mode = BlendEffectMode.Color,
                Foreground = new ColorSourceEffect
                {
                    Name = "LuminosityColorEffect",
                    Color = convertedLuminosityColor,
                },
                Background = gaussianBlurEffect
            };

            ColorSourceEffect tintColorEffect = new()
            {
                Name = "TintColorEffect",
                Color = convertedTintColor,
            };

            BlendEffect tintAndLuminosityColorEffect = new()
            {
                Mode = BlendEffectMode.Luminosity,
                Foreground = tintColorEffect,
                Background = luminosityColorEffect
            };

            OpacityEffect tintColorOpacityEffect = new()
            {
                Name = "TintColorOpacityEffect",
                Opacity = convertedTintColor.A is 255 ? 0f : 1f,
                Source = tintAndLuminosityColorEffect
            };

            ColorSourceEffect tintColorEffectWithoutAlphaEffect = new()
            {
                Name = "TintColorEffectWithoutAlpha",
                Color = convertedTintColor
            };

            OpacityEffect TintColorWithoutAlphaOpacityEffect = new()
            {
                Name = "TintColorWithoutAlphaOpacityEffect",
                Opacity = convertedTintColor.A is 255 ? 1f : 0f,
                Source = tintColorEffectWithoutAlphaEffect,
            };

            BorderEffect noiseBorderEffect = new()
            {
                Source = new CompositionEffectSourceParameter("noise"),
                ExtendX = CanvasEdgeBehavior.Wrap,
                ExtendY = CanvasEdgeBehavior.Wrap,
            };

            OpacityEffect noiseEffect = new()
            {
                Opacity = 0.02f,
                Source = noiseBorderEffect,
            };

            CompositeEffect compositeEffect = new()
            {
                Mode = CanvasComposite.SourceOver,
                Sources =
                {
                    hostBackdropLayerEffect,
                    tintColorOpacityEffect,
                    TintColorWithoutAlphaOpacityEffect,
                    noiseEffect
                }
            };

            CompositionSurfaceBrush noiseBrush = compositor.CreateSurfaceBrush();
            noiseBrush.Stretch = CompositionStretch.None;
            MemoryStream memoryStream = new();
            MileXamlBlankAppNetFramework.Resource.NoiseAsset_256x256_PNG.Save(memoryStream, ImageFormat.Png);
            memoryStream.Seek(0, SeekOrigin.Begin);
            noiseBrush.Surface = LoadedImageSurface.StartLoadFromStream(memoryStream.AsRandomAccessStream());
            memoryStream.Dispose();

            CompositionEffectBrush desktopAcrylicBrush = compositor.CreateEffectFactory(compositeEffect).CreateBrush();

            CompositionBrush backdropBrush = IsHostBackdropSupported && UseHostBackdropBrush ? compositor.CreateHostBackdropBrush() : compositor.CreateBackdropBrush();

            desktopAcrylicBrush.SetSourceParameter("source", backdropBrush);
            desktopAcrylicBrush.SetSourceParameter("noise", noiseBrush);

            return desktopAcrylicBrush;
        }

        private CompositionBrush CreateCrossFadeEffectBrush(Compositor compositor, CompositionBrush from, CompositionBrush to)
        {
            CrossFadeEffect crossFadeEffect = new()
            {
                Name = "Crossfade",
                Source1 = new CompositionEffectSourceParameter("source1"),
                Source2 = new CompositionEffectSourceParameter("source2"),
                CrossFade = 0
            };

            CompositionEffectBrush crossFadeEffectBrush = compositor.CreateEffectFactory(crossFadeEffect, ["Crossfade.CrossFade"]).CreateBrush();
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
                POWERBROADCAST_SETTING setting = (POWERBROADCAST_SETTING)Marshal.PtrToStructure(lParam, typeof(POWERBROADCAST_SETTING));

                if (setting.PowerSetting == GUID_POWER_SAVING_STATUS)
                {
                    Kernel32Library.GetSystemPowerStatus(out SYSTEM_POWER_STATUS status);
                    isEnergySaverEnabled = Convert.ToBoolean(status.SystemStatusFlag);

                    if (isInitialized)
                    {
                        formRoot.BeginInvoke(() =>
                        {
                            UpdateBrush();
                        });
                    }
                }
            }

            return Comctl32Library.DefSubclassProc(hWnd, Msg, wParam, lParam);
        }
    }
}
