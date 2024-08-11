using Mile.Xaml;
using Windows.UI.Xaml;

namespace MileXamlBlankAppNetCore
{
    sealed partial class App : Application
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
