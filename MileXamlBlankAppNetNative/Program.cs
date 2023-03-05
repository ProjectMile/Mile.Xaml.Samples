using System;
using System.Runtime.InteropServices;
using Native.Win32.System.LibraryLoader;
using Native.Win32.System.Threading;
using Native.Win32.UI.Input.KeyboardAndMouse;
using Native.Win32.UI.WindowsAndMessaging;

namespace MileXamlBlankAppNetNative
{
    public static class Program
    {
        public static void Main()
        {
            App app = new();

            var hWnd = Window.CreateWindowExW(
                dwExStyle: Window.ExStyle.Left,
                lpClassName: "Mile.Xaml.ContentWindow",
                lpWindowName: "MileXamlBlankApp (.Net Native)",
                dwStyle: Window.Style.OverLappedWindow,
                X: Window.CreateUseDefault,
                Y: 0,
                nWidth: Window.CreateUseDefault,
                nHeight: 0,
                hInstance: Module.GetModuleHandleW(null),
                lpParam: Marshal.GetIUnknownForObject(new MainPage()));
            if (hWnd == IntPtr.Zero)
            {
                Process.ExitProcess(unchecked((uint)-1));
            }

            Window.ShowWindow(hWnd, Window.ShowCmd.Default);
            Window.UpdateWindow(hWnd);

            Message.Msg msg;
            while (Message.GetMessageW(
                lpMsg: out msg,
                wMsgFilterMin: 0,
                wMsgFilterMax: 0))
            {
                if (msg.message == (uint)Keyboard.Notifications.SysKeyDown
                    && msg.wParam == (UIntPtr)Keyboard.VirtualKey.F4)
                {
                    Message.SendMessageW(
                        Window.Ancestor.GetAncestor(
                            hWnd,
                            Window.Ancestor.Flag.Root),
                        msg.message,
                        msg.wParam,
                        msg.lParam);
                    continue;
                }

                Message.TranslateMessage(in msg);
                Message.DispatchMessageW(in msg);
            }

            app.Dispose();
            // Due to the design of .Net Native, the program won't exit when returning a number.
            Process.ExitProcess(msg.wParam.ToUInt32());
        }
    }
}
