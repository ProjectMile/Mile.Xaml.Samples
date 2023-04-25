using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace MileXamlBlankAppNetFrameworkModern
{
    sealed partial class App : Application
    {
        WindowsXamlManager windowsXamlManager = null;

        public App()
        {
            this.windowsXamlManager = WindowsXamlManager.InitializeForCurrentThread();
            this.InitializeComponent();
        }

        public void Close()
        {
            this.Exit();
            this.windowsXamlManager.Dispose();
            this.windowsXamlManager = null;
        }
    }
}
