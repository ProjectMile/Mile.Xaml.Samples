using System;
using System.Runtime.InteropServices;

namespace Mile.Xaml
{
    public class NativeWrapper
    {
        [DllImport("Mile.Xaml.dll")]
        public static extern IntPtr MileXamlGetCoreWindowHandle();

        [DllImport("Mile.Xaml.dll", PreserveSig = true)]
        public static extern void MileXamlSetXamlContentForContentWindow(
            IntPtr WindowHandle,
            IntPtr XamlContent);

        [DllImport("Mile.Xaml.dll")]
        public static extern IntPtr MileXamlContentWindowDefaultCallback(
            IntPtr hWnd,
            uint uMsg,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport("Mile.Xaml.dll")]
        public static extern int MileXamlContentWindowDefaultMessageLoop();

        [DllImport("Mile.Xaml.dll", PreserveSig = true)]
        public static extern void MileXamlGetTransparentBackgroundAttribute(
            out bool TransparentBackground);

        [DllImport("Mile.Xaml.dll", PreserveSig = true)]
        public static extern void MileXamlSetTransparentBackgroundAttribute(
            bool TransparentBackground);

        [DllImport("Mile.Xaml.dll", PreserveSig = true)]
        public static extern void MileXamlGetPreferredDarkModeAttribute(
            out bool PreferredDarkMode);

        [DllImport("Mile.Xaml.dll", PreserveSig = true)]
        public static extern void MileXamlSetPreferredDarkModeAttribute(
            bool PreferredDarkMode);

        [DllImport("Mile.Xaml.dll", PreserveSig = true)]
        public static extern void MileXamlThreadInitialize();

        [DllImport("Mile.Xaml.dll", PreserveSig = true)]
        public static extern void MileXamlThreadUninitialize();

        [DllImport("Mile.Xaml.dll", PreserveSig = true)]
        public static extern void MileXamlGlobalInitialize();

        [DllImport("Mile.Xaml.dll", PreserveSig = true)]
        public static extern void MileXamlGlobalUninitialize();
    }
}
