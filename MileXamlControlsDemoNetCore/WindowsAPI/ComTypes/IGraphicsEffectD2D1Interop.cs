using MileXamlControlsDemoNetCore.WindowsAPI.ComTypes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Graphics.Effects;
using WinRT;
using WinRT.Interop;

namespace ABI.MileXamlControlsDemoNetCore.WindowsAPI.ComTypes
{
    public static class IGraphicsEffectD2D1InteropMethods
    {
        public static Guid IID { get; } = typeof(IGraphicsEffectD2D1Interop).GUID;
        public static IntPtr AbiToProjectionVftablePtr { get; } = IGraphicsEffectD2D1Interop.Vftbl.InitVtbl();
    }
}

namespace MileXamlControlsDemoNetCore.WindowsAPI.ComTypes
{
    [WindowsRuntimeType, Guid("2FC57384-A068-44D7-A331-30982FCF7177")]
    public partial interface IGraphicsEffectD2D1Interop
    {
        int GetEffectId(out Guid id);

        int GetNamedPropertyMapping(IntPtr name, out uint index, out GRAPHICS_EFFECT_PROPERTY_MAPPING mapping);

        int GetPropertyCount(out uint count);

        int GetProperty(uint index, out IntPtr value);

        int GetSource(uint index, out IGraphicsEffectSource source);

        int GetSourceCount(out uint count);

        internal unsafe struct Vftbl
        {
            public static IntPtr InitVtbl()
            {
                Vftbl* lpVtbl = (Vftbl*)ComWrappersSupport.AllocateVtableMemory(typeof(Vftbl), sizeof(Vftbl));

                lpVtbl->IUnknownVftbl = IUnknownVftbl.AbiToProjectionVftbl;
                lpVtbl->GetEffectId = &GetEffectIdFromAbi;
                lpVtbl->GetNamedPropertyMapping = &GetNamedPropertyMappingFromAbi;
                lpVtbl->GetPropertyCount = &GetPropertyCountFromAbi;
                lpVtbl->GetProperty = &GetPropertyFromAbi;
                lpVtbl->GetSource = &GetSourceFromAbi;
                lpVtbl->GetSourceCount = &GetSourceCountFromAbi;
                return (IntPtr)lpVtbl;
            }

            private IUnknownVftbl IUnknownVftbl;

            // interface delegates
            private delegate* unmanaged[MemberFunction]<IntPtr, Guid*, int> GetEffectId;

            private delegate* unmanaged[MemberFunction]<IntPtr, IntPtr, uint*, GRAPHICS_EFFECT_PROPERTY_MAPPING*, int> GetNamedPropertyMapping;
            private delegate* unmanaged[MemberFunction]<IntPtr, uint*, int> GetPropertyCount;
            private delegate* unmanaged[MemberFunction]<IntPtr, uint, IntPtr*, int> GetProperty;
            private delegate* unmanaged[MemberFunction]<IntPtr, uint, IntPtr*, int> GetSource;
            private delegate* unmanaged[MemberFunction]<IntPtr, uint*, int> GetSourceCount;

            // interface implementation
            [UnmanagedCallersOnly(CallConvs = [typeof(CallConvMemberFunction)])]
            private static int GetEffectIdFromAbi(IntPtr thisPtr, Guid* value)
            {
                try
                {
                    if (value != null)
                    {
                        *value = Guid.Empty;
                    }

                    int hr = ComWrappersSupport.FindObject<IGraphicsEffectD2D1Interop>(thisPtr).GetEffectId(out Guid v);
                    if (hr >= 0)
                    {
                        if (value != null)
                        {
                            *value = v;
                        }
                    }
                    return hr;
                }
                catch (Exception e)
                {
                    ExceptionHelpers.SetErrorInfo(e);
                    return Marshal.GetHRForException(e);
                }
            }

            [UnmanagedCallersOnly(CallConvs = [typeof(CallConvMemberFunction)])]
            private static int GetNamedPropertyMappingFromAbi(IntPtr thisPtr, IntPtr name, uint* index, GRAPHICS_EFFECT_PROPERTY_MAPPING* mapping)
            {
                try
                {
                    if (index != null)
                    {
                        *index = 0;
                    }

                    if (mapping != null)
                    {
                        *mapping = 0;
                    }

                    int hr = ComWrappersSupport.FindObject<IGraphicsEffectD2D1Interop>(thisPtr).GetNamedPropertyMapping(name, out uint i, out GRAPHICS_EFFECT_PROPERTY_MAPPING m);
                    if (hr >= 0)
                    {
                        if (index != null)
                        {
                            *index = i;
                        }

                        if (mapping != null)
                        {
                            *mapping = m;
                        }
                    }
                    return hr;
                }
                catch (Exception e)
                {
                    ExceptionHelpers.SetErrorInfo(e);
                    return Marshal.GetHRForException(e);
                }
            }

            [UnmanagedCallersOnly(CallConvs = [typeof(CallConvMemberFunction)])]
            private static int GetPropertyCountFromAbi(IntPtr thisPtr, uint* value)
            {
                try
                {
                    if (value != null)
                    {
                        *value = 0;
                    }

                    int hr = ComWrappersSupport.FindObject<IGraphicsEffectD2D1Interop>(thisPtr).GetPropertyCount(out uint v);
                    if (hr >= 0)
                    {
                        *value = v;
                    }
                    return hr;
                }
                catch (Exception e)
                {
                    ExceptionHelpers.SetErrorInfo(e);
                    return Marshal.GetHRForException(e);
                }
            }

            [UnmanagedCallersOnly(CallConvs = [typeof(CallConvMemberFunction)])]
            private static int GetPropertyFromAbi(IntPtr thisPtr, uint index, IntPtr* value)
            {
                try
                {
                    if (value != null)
                    {
                        *value = 0;
                    }

                    int hr = ComWrappersSupport.FindObject<IGraphicsEffectD2D1Interop>(thisPtr).GetProperty(index, out IntPtr v);
                    if (hr >= 0)
                    {
                        *value = v;
                    }
                    return hr;
                }
                catch (Exception e)
                {
                    ExceptionHelpers.SetErrorInfo(e);
                    return Marshal.GetHRForException(e);
                }
            }

            [UnmanagedCallersOnly(CallConvs = [typeof(CallConvMemberFunction)])]
            private static int GetSourceFromAbi(IntPtr thisPtr, uint index, IntPtr* value)
            {
                try
                {
                    if (value != null)
                    {
                        *value = 0;
                    }

                    int hr = ComWrappersSupport.FindObject<IGraphicsEffectD2D1Interop>(thisPtr).GetSource(index, out IGraphicsEffectSource v);
                    if (hr >= 0)
                    {
                        IntPtr unk = MarshalInspectable<IGraphicsEffectSource>.FromManaged(v!);
                        *value = unk;
                    }
                    return hr;
                }
                catch (Exception e)
                {
                    ExceptionHelpers.SetErrorInfo(e);
                    return Marshal.GetHRForException(e);
                }
            }

            [UnmanagedCallersOnly(CallConvs = [typeof(CallConvMemberFunction)])]
            private static int GetSourceCountFromAbi(IntPtr thisPtr, uint* value)
            {
                try
                {
                    if (value != null)
                    {
                        *value = 0;
                    }

                    int hr = ComWrappersSupport.FindObject<IGraphicsEffectD2D1Interop>(thisPtr).GetSourceCount(out uint v);
                    if (hr >= 0)
                    {
                        *value = v;
                    }
                    return hr;
                }
                catch (Exception e)
                {
                    ExceptionHelpers.SetErrorInfo(e);
                    return Marshal.GetHRForException(e);
                }
            }
        }
    }
}
