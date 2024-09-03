using MileXamlBlankAppNetCoreModern.Backdrop;
using MileXamlBlankAppNetCoreModern.UI.Backdrop;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.UI;
using Windows.UI.Composition.Desktop;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MileXamlBlankAppNetCore
{
    public sealed partial class MainPage : Page
    {
        private DesktopWindowTarget DesktopWindowTarget { get; set; }

        private ElementTheme currentTheme = ElementTheme.Default;
        private bool currentInputActiveState = false;
        private SystemBackdrop currentSystemBackdrop = null;

        public string FrameworkDescription => RuntimeInformation.FrameworkDescription;
        public bool IsDynamicCodeSupported => RuntimeFeature.IsDynamicCodeSupported;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var contentDialog = new ContentDialog
            {
                Title = "Hello world",
                Content = "Where do you want to go today?",
                PrimaryButtonText = "OK",
                XamlRoot = (sender as Button).XamlRoot,
            };
            await contentDialog.ShowAsync();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DesktopWindowTarget = BackdropHelper.InitializeDesktopWindowTarget(Program.MainForm, false);

            currentSystemBackdrop = new MicaBackdrop(DesktopWindowTarget, this, Program.MainForm)
            {
                Kind = MicaKind.Base,
                RequestedTheme = currentTheme,
                IsInputActive = currentInputActiveState
            };
            currentSystemBackdrop.InitializeBackdrop();

            currentTheme = ElementTheme.Default;
            currentInputActiveState = false;
            RequestedTheme = currentTheme;

            SystemBackdropNameText.Text = "MicaBase";
            ThemeNameText.Text = currentTheme.ToString();
            InputActiveStateText.Text = currentInputActiveState.ToString();
        }

        private void SwitchSystemBackdropClick(object sender, RoutedEventArgs args)
        {
            if (SystemBackdropNameText.Text == "None")
            {
                Background = new SolidColorBrush(Colors.Transparent);
                currentSystemBackdrop?.Dispose();
                currentSystemBackdrop = null;
                currentSystemBackdrop = new MicaBackdrop(DesktopWindowTarget, this, Program.MainForm)
                {
                    Kind = MicaKind.Base,
                    RequestedTheme = currentTheme,
                    IsInputActive = currentInputActiveState
                };
                currentSystemBackdrop.InitializeBackdrop();

                SystemBackdropNameText.Text = "MicaBase";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "MicaBase")
            {
                Background = new SolidColorBrush(Colors.Transparent);
                currentSystemBackdrop?.Dispose();
                currentSystemBackdrop = null;
                currentSystemBackdrop = new MicaBackdrop(DesktopWindowTarget, this, Program.MainForm)
                {
                    Kind = MicaKind.BaseAlt,
                    RequestedTheme = currentTheme,
                    IsInputActive = currentInputActiveState
                };
                currentSystemBackdrop.InitializeBackdrop();

                SystemBackdropNameText.Text = "MicaAlt";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "MicaAlt")
            {
                Background = new SolidColorBrush(Colors.Transparent);
                currentSystemBackdrop?.Dispose();
                currentSystemBackdrop = null;
                currentSystemBackdrop = new DesktopAcrylicBackdrop(DesktopWindowTarget, this, Program.MainForm)
                {
                    Kind = DesktopAcrylicKind.Default,
                    RequestedTheme = currentTheme,
                    IsInputActive = currentInputActiveState,
                    UseHostBackdropBrush = true
                };
                currentSystemBackdrop.InitializeBackdrop();

                SystemBackdropNameText.Text = "DesktopAcrylicDefault";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "DesktopAcrylicDefault")
            {
                Background = new SolidColorBrush(Colors.Transparent);
                currentSystemBackdrop?.Dispose();
                currentSystemBackdrop = null;
                currentSystemBackdrop = new DesktopAcrylicBackdrop(DesktopWindowTarget, this, Program.MainForm)
                {
                    Kind = DesktopAcrylicKind.Base,
                    RequestedTheme = currentTheme,
                    IsInputActive = currentInputActiveState,
                    UseHostBackdropBrush = true
                };
                currentSystemBackdrop.InitializeBackdrop();

                SystemBackdropNameText.Text = "DesktopAcrylicBase";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "DesktopAcrylicBase")
            {
                Background = new SolidColorBrush(Colors.Transparent);
                currentSystemBackdrop?.Dispose();
                currentSystemBackdrop = null;
                currentSystemBackdrop = new DesktopAcrylicBackdrop(DesktopWindowTarget, this, Program.MainForm)
                {
                    Kind = DesktopAcrylicKind.Thin,
                    RequestedTheme = currentTheme,
                    IsInputActive = currentInputActiveState,
                    UseHostBackdropBrush = true
                };
                currentSystemBackdrop.InitializeBackdrop();

                SystemBackdropNameText.Text = "DesktopAcrylicThin";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "DesktopAcrylicThin")
            {
                SystemBackdropNameText.Text = "None";
                currentSystemBackdrop?.Dispose();
                currentSystemBackdrop = null;
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();

                if (ActualTheme is ElementTheme.Light)
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 243, 243, 243));
                }
                else
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
                }
            }
        }

        private void SwitchThemeClick(object sender, RoutedEventArgs args)
        {
            if (currentTheme is ElementTheme.Default)
            {
                RequestedTheme = ElementTheme.Light;
                currentTheme = ElementTheme.Light;
                ThemeNameText.Text = ElementTheme.Light.ToString();
                if (currentSystemBackdrop is not null)
                {
                    currentSystemBackdrop.RequestedTheme = ElementTheme.Light;
                }
                else
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 243, 243, 243));
                }
            }
            else if (currentTheme is ElementTheme.Light)
            {
                RequestedTheme = ElementTheme.Dark;
                currentTheme = ElementTheme.Dark;
                ThemeNameText.Text = ElementTheme.Dark.ToString();
                if (currentSystemBackdrop is not null)
                {
                    currentSystemBackdrop.RequestedTheme = ElementTheme.Dark;
                }
                else
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
                }
            }
            else
            {
                RequestedTheme = ElementTheme.Default;
                currentTheme = ElementTheme.Default;
                ThemeNameText.Text = ElementTheme.Default.ToString();
                if (currentSystemBackdrop is not null)
                {
                    currentSystemBackdrop.RequestedTheme = ElementTheme.Default;
                }
                else
                {
                    if (ActualTheme is ElementTheme.Light)
                    {
                        Background = new SolidColorBrush(Color.FromArgb(255, 243, 243, 243));
                    }
                    else
                    {
                        Background = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
                    }
                }
            }
        }

        private void SwitchInputActiveStateClick(object sender, RoutedEventArgs args)
        {
            if (currentInputActiveState)
            {
                currentInputActiveState = false;
                InputActiveStateText.Text = currentInputActiveState.ToString();
                if (currentSystemBackdrop is not null)
                {
                    currentSystemBackdrop.IsInputActive = false;
                }
            }
            else
            {
                currentInputActiveState = true;
                InputActiveStateText.Text = currentInputActiveState.ToString();
                if (currentSystemBackdrop is not null)
                {
                    currentSystemBackdrop.IsInputActive = true;
                }
            }
        }

        private void OnActualThemeChanged(FrameworkElement sender, object args)
        {
            if (currentSystemBackdrop is not null)
            {
                if (ActualTheme is ElementTheme.Light)
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 243, 243, 243));
                }
                else
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
                }
            }
        }
    }
}
