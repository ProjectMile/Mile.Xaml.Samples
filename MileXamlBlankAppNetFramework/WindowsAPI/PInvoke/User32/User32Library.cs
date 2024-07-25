using System;
using System.Runtime.InteropServices;

namespace MileXamlBlankAppNetFrameworkModern.WindowsAPI.PInvoke.User32
{
    public static class User32Library
    {
        private const string User32 = "user32.dll";

        [DllImport(User32, CharSet = CharSet.Unicode, EntryPoint = "RegisterPowerSettingNotification", SetLastError = false)]
        public static extern IntPtr RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, uint Flags);

        [DllImport(User32, CharSet = CharSet.Unicode, EntryPoint = "UnregisterPowerSettingNotification", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterPowerSettingNotification(IntPtr handle);
    }
}
