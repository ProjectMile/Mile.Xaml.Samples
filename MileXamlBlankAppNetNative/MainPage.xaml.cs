using Windows.UI.Xaml.Controls;

namespace MileXamlBlankAppNetNative
{
    public sealed partial class MainPage : Page
    {
        public MainPage() => this.InitializeComponent();

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs _)
            => (sender as Button).Content = "Clicked";
    }
}
