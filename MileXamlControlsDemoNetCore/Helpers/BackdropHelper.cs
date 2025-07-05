using MileXamlControlsDemoNetCore.WindowsAPI.ComTypes;
using Windows.Foundation;

namespace MileXamlControlsDemoNetCore.Helpers
{
    public static class BackdropHelper
    {
        public static IPropertyValueStatics PropertyValueStatics { get; } = PropertyValue.As<IPropertyValueStatics>();
    }
}
