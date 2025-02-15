using System.Runtime.InteropServices;

namespace MileXamlControlsDemoNetCore.WindowsAPI.PInvoke.Kernel32
{
    public static partial class Kernel32Library
    {
        private const string Kernel32 = "kernel32.dll";

        public const long APPMODEL_ERROR_NO_PACKAGE = 15700L;

        [LibraryImport(Kernel32, EntryPoint = "GetSystemPowerStatus", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS lpSystemPowerStatus);
    }
}
