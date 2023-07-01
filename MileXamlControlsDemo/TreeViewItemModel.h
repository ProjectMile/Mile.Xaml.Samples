#pragma once

#include "TreeViewItemModel.g.h"

#include "winrt/Windows.Foundation.Collections.h"

namespace winrt::MileXamlControlsDemo::implementation
{
    struct TreeViewItemModel : TreeViewItemModelT<TreeViewItemModel>
    {
    public:
        TreeViewItemModel() = default;

        bool IsSelected();
        void IsSelected(bool value);

        winrt::hstring Name();
        void Name(winrt::hstring value);

        winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> ChildrenNode();
        void ChildrenNode(winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> value);

    private:
        bool _isSelected = false;
        winrt::hstring _name = L"";
        winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> _childrenNode = winrt::single_threaded_observable_vector<winrt::MileXamlControlsDemo::TreeViewItemModel>();
    };
}

namespace winrt::MileXamlControlsDemo::factory_implementation
{
    struct TreeViewItemModel : TreeViewItemModelT<TreeViewItemModel, implementation::TreeViewItemModel>
    {
    };
}
