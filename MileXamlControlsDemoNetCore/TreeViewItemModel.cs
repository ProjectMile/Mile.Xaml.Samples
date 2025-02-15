using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileXamlControlsDemoNetCore
{
    public class TreeViewItemModel
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public ObservableCollection<TreeViewItemModel> ChildrenNode { get; set; }
    }
}
