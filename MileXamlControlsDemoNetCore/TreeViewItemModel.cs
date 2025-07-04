using System.Collections.ObjectModel;

namespace MileXamlControlsDemoNetCore
{
    public class TreeViewItemModel
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public ObservableCollection<TreeViewItemModel> ChildrenNode { get; set; }
    }
}
