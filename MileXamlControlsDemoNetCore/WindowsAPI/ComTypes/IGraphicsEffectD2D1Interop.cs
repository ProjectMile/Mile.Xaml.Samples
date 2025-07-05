using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using WinRT;

namespace MileXamlControlsDemoNetCore.WindowsAPI.ComTypes
{
    [GeneratedComInterface, WindowsRuntimeType, Guid("2FC57384-A068-44D7-A331-30982FCF7177")]
    public partial interface IGraphicsEffectD2D1Interop
    {
        [PreserveSig]
        int GetEffectId(out Guid id);

        [PreserveSig]
        int GetNamedPropertyMapping([MarshalAs(UnmanagedType.LPWStr)] string name, out uint index, out GRAPHICS_EFFECT_PROPERTY_MAPPING mapping);

        [PreserveSig]
        int GetPropertyCount(out uint count);

        [PreserveSig]
        int GetProperty(uint index, out IntPtr value);

        [PreserveSig]
        int GetSource(uint index, out IntPtr source);

        [PreserveSig]
        int GetSourceCount(out uint count);
    }
}
