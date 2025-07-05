using System.Collections.ObjectModel;

namespace MileXamlControlsDemoNetFramework
{
    public class TreeViewItemModel
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public ObservableCollection<TreeViewItemModel> ChildrenNode { get; set; }
    }
}
