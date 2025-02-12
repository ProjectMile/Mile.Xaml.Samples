using Mile.Xaml;
using System;
using System.Runtime.InteropServices;

namespace MileXamlBlankAppNetFrameworkNativeBackend
{
    public static class Program
    {
        [Flags]
        enum WS_EX : uint
        {
            None = 0,
            DLGMODALFRAME = 0x00000001,
            NOPARENTNOTIFY = 0x00000004,
            TOPMOST = 0x00000008,
            ACCEPTFILES = 0x00000010,
            TRANSPARENT = 0x00000020,
            MDICHILD = 0x00000040,
            TOOLWINDOW = 0x00000080,
            WINDOWEDGE = 0x00000100,
            CLIENTEDGE = 0x00000200,
            CONTEXTHELP = 0x00000400,
            RIGHT = 0x00001000,
            LEFT = 0x00000000,
            RTLREADING = 0x00002000,
            LTRREADING = 0x00000000,
            LEFTSCROLLBAR = 0x00004000,
            RIGHTSCROLLBAR = 0x00000000,
            CONTROLPARENT = 0x00010000,
            STATICEDGE = 0x00020000,
            APPWINDOW = 0x00040000,
            LAYERED = 0x00080000,
            NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
            LAYOUTRTL = 0x00400000, // Right to left mirroring
            COMPOSITED = 0x02000000,
            NOACTIVATE = 0x08000000,
            OVERLAPPEDWINDOW = (WINDOWEDGE | CLIENTEDGE),
            PALETTEWINDOW = (WINDOWEDGE | TOOLWINDOW | TOPMOST),
        }

        [Flags]
        enum WS : uint
        {
            OVERLAPPED = 0x00000000,
            POPUP = 0x80000000,
            CHILD = 0x40000000,
            MINIMIZE = 0x20000000,
            VISIBLE = 0x10000000,
            DISABLED = 0x08000000,
            CLIPSIBLINGS = 0x04000000,
            CLIPCHILDREN = 0x02000000,
            MAXIMIZE = 0x01000000,
            BORDER = 0x00800000,
            DLGFRAME = 0x00400000,
            VSCROLL = 0x00200000,
            HSCROLL = 0x00100000,
            SYSMENU = 0x00080000,
            THICKFRAME = 0x00040000,
            GROUP = 0x00020000,
            TABSTOP = 0x00010000,

            MINIMIZEBOX = 0x00020000,
            MAXIMIZEBOX = 0x00010000,

            CAPTION = BORDER | DLGFRAME,
            TILED = OVERLAPPED,
            ICONIC = MINIMIZE,
            SIZEBOX = THICKFRAME,
            TILEDWINDOW = OVERLAPPEDWINDOW,

            OVERLAPPEDWINDOW = OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX,
            POPUPWINDOW = POPUP | BORDER | SYSMENU,
            CHILDWINDOW = CHILD,
        }

        public const int CW_USEDEFAULT = (unchecked((int)0x80000000));

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr CreateWindowEx(
            WS_EX dwExStyle,
            string lpClassName,
            string lpWindowName,
            WS dwStyle,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam);

        [DllImport("user32.dll")]
        static extern bool UpdateWindow(
            IntPtr hWnd);

        enum SW
        {
            HIDE = 0,
            SHOWNORMAL = 1,
            NORMAL = 1,
            SHOWMINIMIZED = 2,
            SHOWMAXIMIZED = 3,
            MAXIMIZE = 3,
            SHOWNOACTIVATE = 4,
            SHOW = 5,
            MINIMIZE = 6,
            SHOWMINNOACTIVE = 7,
            SHOWNA = 8,
            RESTORE = 9,
            SHOWDEFAULT = 10,
            FORCEMINIMIZE = 11,
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(
            IntPtr hWnd,
            SW nCmdShow);

        [STAThread]
        private static void Main()
        {
            App app = new();

            MainPage Content = new MainPage();

            IntPtr WindowHandle = CreateWindowEx(
                WS_EX.CLIENTEDGE,
                "Mile.Xaml.ContentWindow",
                "MileXamlBlankApp (.Net 8)",
                WS.OVERLAPPEDWINDOW,
                CW_USEDEFAULT,
                0,
                CW_USEDEFAULT,
                0,
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero,
                Marshal.GetIUnknownForObject(Content));

            ShowWindow(WindowHandle, SW.SHOW);
            UpdateWindow(WindowHandle);

            NativeWrapper.MileXamlContentWindowDefaultMessageLoop();

            app.Close();
        }
    }
}
