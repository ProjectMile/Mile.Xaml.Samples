using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using WinRT;

namespace MileXamlBlankAppNetCoreModern.WindowsAPI.ComTypes
{
    [GeneratedComInterface, Guid("629BDBC8-D932-4FF4-96B9-8D96C5C1E858")]
    public partial interface IPropertyValueStatics
    {
        [PreserveSig]
        int GetIids(out ulong iidCount, out IntPtr iids);

        [PreserveSig]
        int GetRuntimeClassName(out IntPtr className);

        [PreserveSig]
        int GetTrustLevel(out TrustLevel trustLevel);

        [PreserveSig]
        int CreateEmpty(out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt8(byte value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInt16(short value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt16(ushort value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInt32(int value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt32(uint value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInt64(long value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt64(ulong value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateSingle(float value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateDouble(double value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateChar16(IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateBoolean([MarshalAs(UnmanagedType.Bool)] bool value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateString(IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInspectable(IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateGuid(Guid value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateDateTime(IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateTimeSpan(IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreatePoint(IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateSize(IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateRect(IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt8Array(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInt16Array(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] short[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt16Array(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInt32Array(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt32Array(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInt64Array(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] long[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt64Array(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateSingleArray(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateDoubleArray(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateChar16Array(int valueLength, IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateBooleanArray(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, ArraySubType = UnmanagedType.Bool)] bool[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateStringArray(int valueSize, IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInspectableArray(int valueLength, IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateGuidArray(int valueLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateDateTimeArray(int valueLength, IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateTimeSpanArray(int valueLength, IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreatePointArray(int valueLength, IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateSizeArray(int valueLength, IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateRectArray(int valueLength, IntPtr value, out IntPtr propertyValue);
    }
}
