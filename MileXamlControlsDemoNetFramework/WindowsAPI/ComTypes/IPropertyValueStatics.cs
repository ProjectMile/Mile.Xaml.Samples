using System;
using System.Runtime.InteropServices;
using Windows.Foundation;

namespace MileXamlControlsDemoNetFramework.WindowsAPI.ComTypes
{
    [ComImport, Guid("629BDBC8-D932-4FF4-96B9-8D96C5C1E858"), InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface IPropertyValueStatics
    {
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
        int CreateChar16(char value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateBoolean(bool value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateString(IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInspectable([MarshalAs(UnmanagedType.IUnknown)] object value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateGuid(Guid value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateDateTime(DateTime value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateTimeSpan(TimeSpan value, out IntPtr propertyValue);

        [PreserveSig]
        int CreatePoint(Point value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateSize(Size value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateRect(Rect value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt8Array(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInt16Array(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] short[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt16Array(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInt32Array(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt32Array(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInt64Array(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] long[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateUInt64Array(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateSingleArray(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateDoubleArray(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateChar16Array(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] char[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateBooleanArray(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] bool[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateStringArray(int valueSize, IntPtr value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateInspectableArray(int valueLength, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] object[] value, out IntPtr propertyValue);

        [PreserveSig]
        int CreateGuidArray(int valueLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] value, out IntPtr propertyValue);

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
