using System;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Input.KeyboardAndMouse;
using Windows.Win32.UI.WindowsAndMessaging;
using static Windows.Win32.PInvoke;

namespace MileXamlBlankAppNetFrameworkModern
{
    public static class Program
    {
        [STAThread]
        public static unsafe int Main()
        {
            App app = new();

            var hWnd = CreateWindowEx(
                WINDOW_EX_STYLE.WS_EX_LEFT,
                "Mile.Xaml.ContentWindow",
                "MileXamlBlankApp (.Net Framework)",
                WINDOW_STYLE.WS_OVERLAPPEDWINDOW,
                CW_USEDEFAULT,
                0,
                CW_USEDEFAULT,
                0,
                HWND.Null,
                null,
                GetModuleHandle(string.Empty),
                lpParam: Marshal.GetIUnknownForObject(new MainPage()).ToPointer());
            if (hWnd == IntPtr.Zero)
            {
                return -1;
            }

            ShowWindow(hWnd, SHOW_WINDOW_CMD.SW_SHOWDEFAULT);
            UpdateWindow(hWnd);

            MSG msg;
            while (GetMessage(
                &msg,
                HWND.Null,
                0,
                0))
            {
                if (msg.message == WM_SYSKEYDOWN
                    && msg.wParam.Value == (nuint)VIRTUAL_KEY.VK_F4)
                {
                    SendMessage(
                        GetAncestor(
                            hWnd,
                            GET_ANCESTOR_FLAGS.GA_ROOT),
                        msg.message,
                        msg.wParam,
                        msg.lParam);
                    continue;
                }

                TranslateMessage(&msg);
                DispatchMessage(&msg);
            }

            app.Dispose();
            return (int)msg.wParam.Value;
        }
    }
}
