using Mile.Xaml;
using Windows.UI.Xaml;

namespace MileXamlControlsDemoNetFramework
{
    public sealed partial class App : Application
    {
        public App()
        {
            this.ThreadInitialize();
            this.InitializeComponent();
        }

        public void Close()
        {
            this.Exit();
            this.ThreadUninitialize();
        }
    }
}
