using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MileXamlBlankAppNetFrameworkModern
{
    public sealed partial class MainPage : Page
    {
        public MainPage() => this.InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs _)
            => (sender as Button).Content = "Clicked";
    }
}
