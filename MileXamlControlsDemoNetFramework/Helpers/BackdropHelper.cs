using MileXamlControlsDemoNetFramework.WindowsAPI.ComTypes;
using MileXamlControlsDemoNetFramework.WindowsAPI.PInvoke.Combase;
using System;
using System.Runtime.InteropServices;

namespace MileXamlControlsDemoNetFramework.Helpers
{
    public static class BackdropHelper
    {
        public static IPropertyValueStatics PropertyValueStatics { get; } = GetActivationFactory<IPropertyValueStatics>("Windows.Foundation.PropertyValue", typeof(IPropertyValueStatics).GUID);

        public static T GetActivationFactory<T>(string activatableClassId, Guid iid)
        {
            if (!string.IsNullOrEmpty(activatableClassId))
            {
                CombaseLibrary.RoGetActivationFactory(activatableClassId, iid, out IntPtr comp);
                return (T)Marshal.GetObjectForIUnknown(comp);
            }
            else
            {
                return default;
            }
        }
    }
}
