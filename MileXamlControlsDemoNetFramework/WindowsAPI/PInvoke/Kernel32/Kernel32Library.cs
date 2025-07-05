using System.Runtime.InteropServices;

namespace MileXamlControlsDemoNetFramework.WindowsAPI.PInvoke.Kernel32
{
    public static class Kernel32Library
    {
        private const string Kernel32 = "kernel32.dll";

        [DllImport(Kernel32, CharSet = CharSet.Unicode, EntryPoint = "GetSystemPowerStatus", SetLastError = false)]
        public static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS lpSystemPowerStatus);
    }
}
