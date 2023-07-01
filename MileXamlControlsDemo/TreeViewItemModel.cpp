#include "pch.h"
#include "TreeViewItemModel.h"
#if __has_include("TreeViewItemModel.g.cpp")
#include "TreeViewItemModel.g.cpp"
#endif

namespace winrt::MileXamlControlsDemo::implementation
{
    bool TreeViewItemModel::IsSelected()
    {
        return _isSelected;
    }

    void TreeViewItemModel::IsSelected(bool value)
    {
        _isSelected = value;
    }

    winrt::hstring TreeViewItemModel::Name()
    {
        return _name;
    }

    void TreeViewItemModel::Name(winrt::hstring value)
    {
        _name = value;
    }

    winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> TreeViewItemModel::ChildrenNode()
    {
        return _childrenNode;
    }

    void TreeViewItemModel::ChildrenNode(winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> value)
    {
        _childrenNode = value;
    }
}
