using Mile.Xaml;
using System;
using System.Runtime.InteropServices;
using Windows.UI.Xaml;

namespace MileXamlBlankAppNetFrameworkModern
{
    [ComImport]
    [Guid("06636C29-5A17-458D-8EA2-2422D997A922")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface IWindowPrivate
    {
        bool TransparentBackground { get; set; }
    }

    sealed partial class App : Application
    {
        internal static IWindowPrivate GetIWindowPrivateFromCurrentCoreWindow()
        {
            IntPtr CoreWindowIntPtr = Marshal.GetIUnknownForObject(Window.Current);
            try
            {
                return (IWindowPrivate)Marshal.GetTypedObjectForIUnknown(
                    CoreWindowIntPtr,
                    typeof(IWindowPrivate));
            }
            finally
            {
                Marshal.Release(CoreWindowIntPtr);
            }
        }

        public App()
        {
            this.ThreadInitialize();
            var Yolo = GetIWindowPrivateFromCurrentCoreWindow();
            Yolo.TransparentBackground = true;
            this.InitializeComponent();
        }

        public void Close()
        {
            this.Exit();
            this.ThreadUninitialize();
        }
    }
}
