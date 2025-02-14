using System;
using System.Runtime.InteropServices;

namespace MileXamlControlsDemoNetCore.WindowsAPI.PInvoke.User32
{
    public static partial class User32Library
    {
        private const string User32 = "user32.dll";

        [LibraryImport(User32, EntryPoint = "RegisterPowerSettingNotification", SetLastError = false)]
        public static partial IntPtr RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, uint Flags);

        [LibraryImport(User32, EntryPoint = "UnregisterPowerSettingNotification", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool UnregisterPowerSettingNotification(IntPtr handle);
    }
}
