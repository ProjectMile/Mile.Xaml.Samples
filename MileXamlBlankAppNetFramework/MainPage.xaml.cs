using System;
using System.Runtime.InteropServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MileXamlBlankAppNetFrameworkModern
{
    public sealed partial class MainPage : Page
    {
        public string FrameworkDescription => RuntimeInformation.FrameworkDescription;

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
    }
}
