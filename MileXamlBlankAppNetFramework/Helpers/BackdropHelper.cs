using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Windows.System;
using Windows.UI.Composition.Desktop;
using Windows.UI.Xaml;
using MileXamlBlankAppNetFrameworkModern.WindowsAPI.ComTypes;
using MileXamlBlankAppNetFrameworkModern.WindowsAPI.PInvoke.Combase;

namespace MileXamlBlankAppNetFrameworkModern.Backdrop
{
    public static class BackdropHelper
    {
        public static Lazy<IPropertyValueStatics> PropertyValueStatics { get; } = new(() => GetActivationFactory<IPropertyValueStatics>("Windows.Foundation.PropertyValue", typeof(IPropertyValueStatics).GUID));

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

        public static DesktopWindowTarget InitializeDesktopWindowTarget(Form form, bool isTopMost)
        {
            if (form.Handle == IntPtr.Zero)
            {
                throw new NullReferenceException("Form window not initialized");
            }

            DesktopWindowTarget desktopWindowTarget = null;
            if (DispatcherQueue.GetForCurrentThread() is not null)
            {
                ICompositorDesktopInterop interop = Window.Current.Compositor as object as ICompositorDesktopInterop;
                interop.CreateDesktopWindowTarget(form.Handle, isTopMost, out desktopWindowTarget);
            }
            return desktopWindowTarget;
        }
    }
}
