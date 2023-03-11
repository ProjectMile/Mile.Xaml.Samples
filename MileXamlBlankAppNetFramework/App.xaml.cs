using System.Runtime.InteropServices;
using Windows.UI.Xaml;

namespace MileXamlBlankAppNetFrameworkModern
{
    sealed partial class App : Application
    {
        [DllImport("Mile.Xaml.dll", PreserveSig = false)]
        static extern void MileXamlGlobalInitialize();

        [DllImport("Mile.Xaml.dll", PreserveSig = false)]
        static extern void MileXamlGlobalUninitialize();

        public App()
        {
            MileXamlGlobalInitialize();
            this.InitializeComponent();
        }

        public void Close()
        {
            this.Exit();
            MileXamlGlobalUninitialize();
        }
    }
}
