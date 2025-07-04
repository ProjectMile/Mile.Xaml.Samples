using MileXamlControlsDemoNetCore.UI.Backdrop;
using System;
using System.Collections.ObjectModel;
using Windows.Media.Core;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

#pragma warning disable IDE0060

namespace MileXamlControlsDemoNetCore
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<TreeViewItemModel> TreeViewDataList { get; } = [
            new() {
                Name = "TreeView Root Node 1", IsSelected = true,
                ChildrenNode = [
                    new() { Name = "TreeView child Node 1", IsSelected = false },
                    new() { Name = "TreeView child Node 2", IsSelected = false },
                    new() { Name = "TreeView child Node 3", IsSelected = false }
                ]
            },
            new() {
                Name = "TreeView Root Node 2", IsSelected = false,
                ChildrenNode = [
                    new() { Name = "TreeView child Node 4", IsSelected = false },
                    new() { Name = "TreeView child Node 5", IsSelected = false },
                ]
            }
        ];

        private ElementTheme currentTheme = ElementTheme.Default;
        private bool currentInputActiveState = false;

        public MainPage()
        {
            InitializeComponent();

            var mediaUri = new Uri("C:\\Windows\\SystemResources\\Windows.UI.SettingsAppThreshold\\SystemSettings\\Assets\\SDRSample.mkv");
            MediaPlayer.Source = MediaSource.CreateFromUri(mediaUri);
            inkToolbar.TargetInkCanvas = inkCanvasDemo;
        }

        private async void HyperlinkButton_Click(object sender, RoutedEventArgs args)
        {
            var vp9LinkUri = new Uri("ms-windows-store://pdp/?productid=9N4D0MSMP0PT");
            await Launcher.LaunchUriAsync(vp9LinkUri);
        }

        private async void HyperlinkButton_Click1(object sender, RoutedEventArgs args)
        {
            var vp9LinkUri = new Uri("https://learn.microsoft.com/en-us/answers/questions/635070/(ver-10-0-19041-0)-c-winrt-treeview-nodes-not-prop?childtoview=635698");
            await Launcher.LaunchUriAsync(vp9LinkUri);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Background = new MicaBrush(MicaKind.Base, this, Program.MainForm, currentInputActiveState);

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
                Background = new MicaBrush(MicaKind.Base, this, Program.MainForm, currentInputActiveState);

                SystemBackdropNameText.Text = "MicaBase";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "MicaBase")
            {
                Background = new MicaBrush(MicaKind.BaseAlt, this, Program.MainForm, currentInputActiveState);

                SystemBackdropNameText.Text = "MicaAlt";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "MicaAlt")
            {
                Background = new DesktopAcrylicBrush(DesktopAcrylicKind.Default, this, Program.MainForm, currentInputActiveState, true);

                SystemBackdropNameText.Text = "DesktopAcrylicDefault";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "DesktopAcrylicDefault")
            {
                Background = new DesktopAcrylicBrush(DesktopAcrylicKind.Base, this, Program.MainForm, currentInputActiveState, true);

                SystemBackdropNameText.Text = "DesktopAcrylicBase";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "DesktopAcrylicBase")
            {
                Background = new DesktopAcrylicBrush(DesktopAcrylicKind.Thin, this, Program.MainForm, currentInputActiveState, true);

                SystemBackdropNameText.Text = "DesktopAcrylicThin";
                ThemeNameText.Text = currentTheme.ToString();
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else if (SystemBackdropNameText.Text == "DesktopAcrylicThin")
            {
                SystemBackdropNameText.Text = "None";
                ThemeNameText.Text = currentTheme.ToString();

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
                if (SystemBackdropNameText.Text == "None")
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 243, 243, 243));
                }
            }
            else if (currentTheme is ElementTheme.Light)
            {
                RequestedTheme = ElementTheme.Dark;
                currentTheme = ElementTheme.Dark;
                ThemeNameText.Text = ElementTheme.Dark.ToString();
                if (SystemBackdropNameText.Text == "None")
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
                }
            }
            else
            {
                RequestedTheme = ElementTheme.Default;
                currentTheme = ElementTheme.Default;
                ThemeNameText.Text = ElementTheme.Default.ToString();
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

        private void SwitchInputActiveStateClick(object sender, RoutedEventArgs args)
        {
            if (currentInputActiveState)
            {
                currentInputActiveState = false;
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }
            else
            {
                currentInputActiveState = true;
                InputActiveStateText.Text = currentInputActiveState.ToString();
            }

            if (SystemBackdropNameText.Text == "Base")
            {
                Background = new MicaBrush(MicaKind.Base, this, Program.MainForm, currentInputActiveState);
            }
            else if (SystemBackdropNameText.Text == "MicaAlt")
            {
                Background = new MicaBrush(MicaKind.BaseAlt, this, Program.MainForm, currentInputActiveState);
            }
            else if (SystemBackdropNameText.Text == "DesktopAcrylicDefault")
            {
                Background = new DesktopAcrylicBrush(DesktopAcrylicKind.Default, this, Program.MainForm, currentInputActiveState, true);
            }
            else if (SystemBackdropNameText.Text == "DesktopAcrylicBase")
            {
                Background = new DesktopAcrylicBrush(DesktopAcrylicKind.Base, this, Program.MainForm, currentInputActiveState, true);
            }
            else if (SystemBackdropNameText.Text == "DesktopAcrylicThin")
            {
                Background = new DesktopAcrylicBrush(DesktopAcrylicKind.Thin, this, Program.MainForm, currentInputActiveState, true);
            }
        }

        private void OnActualThemeChanged(FrameworkElement sender, object args)
        {
            if (SystemBackdropNameText.Text == "None")
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
