using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Windows.System;
using Windows.UI.Composition.Desktop;
using Windows.UI.Xaml;
using MileXamlControlsDemoNetCore.WindowsAPI.ComTypes;
using MileXamlControlsDemoNetCore.WindowsAPI.PInvoke.Combase;
using System.Runtime.InteropServices.Marshalling;

namespace MileXamlControlsDemoNetCore.Backdrop
{
    public static class BackdropHelper
    {
        private static readonly StrategyBasedComWrappers strategyBasedComWrappers = new();

        public static Lazy<IPropertyValueStatics> PropertyValueStatics { get; } = new(() => GetActivationFactory<IPropertyValueStatics>("Windows.Foundation.PropertyValue", typeof(IPropertyValueStatics).GUID));

        public static T GetActivationFactory<T>(string activatableClassId, Guid iid)
        {
            if (!string.IsNullOrEmpty(activatableClassId))
            {
                Marshal.ThrowExceptionForHR(CombaseLibrary.WindowsCreateString(activatableClassId, activatableClassId.Length, out IntPtr stringPtr));
                _ = CombaseLibrary.RoGetActivationFactory(stringPtr, iid, out IntPtr comp);
                return (T)strategyBasedComWrappers.GetOrCreateObjectForComInstance(comp, CreateObjectFlags.None);
            }
            else
            {
                return default;
            }
        }

        public static DesktopWindowTarget InitializeDesktopWindowTarget(Form form, bool isTopMost)
        {
            if (form.Handle == IntPtr.Zero)
            {
                throw new NullReferenceException("Form window not initialized");
            }

            IntPtr desktopWindowTargetPtr = IntPtr.Zero;
            if (DispatcherQueue.GetForCurrentThread() is not null)
            {
                ICompositorDesktopInterop interop = Window.Current.Compositor as object as ICompositorDesktopInterop;
                interop.CreateDesktopWindowTarget(form.Handle, isTopMost, out desktopWindowTargetPtr);
            }

            return desktopWindowTargetPtr != IntPtr.Zero ? DesktopWindowTarget.FromAbi(desktopWindowTargetPtr) : null;
        }
    }
}
