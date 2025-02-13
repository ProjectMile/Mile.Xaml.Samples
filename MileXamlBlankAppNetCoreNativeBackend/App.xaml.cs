using Mile.Xaml;
using Windows.UI.Xaml;

namespace MileXamlBlankAppNetCore
{
    sealed partial class App : Application
    {
        public App()
        {
            NativeWrapper.MileXamlGlobalInitialize();
            this.InitializeComponent();
        }

        public void Close()
        {
            this.Exit();
            NativeWrapper.MileXamlGlobalUninitialize();
        }
    }
}
