#pragma once

#include "MainPage.g.h"

#include "winrt/Windows.Foundation.Collections.h"

namespace winrt::MileXamlControlsDemo::implementation
{
    struct MainPage : MainPageT<MainPage>
    {
    public:
        MainPage() = default;

        void InitializeComponent();

        int32_t MyProperty();
        void MyProperty(int32_t value);

        void ClickHandler(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args);
        void HyperlinkButton_Click(winrt::Windows::Foundation::IInspectable const&, winrt::Windows::UI::Xaml::RoutedEventArgs const&);
        void HyperlinkButton_Click1(winrt::Windows::Foundation::IInspectable const&, winrt::Windows::UI::Xaml::RoutedEventArgs const&);

        winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> TreeViewDataList();
        void TreeViewDataList(winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> value);

    private:
        winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> _treeViewDataList = winrt::single_threaded_observable_vector<winrt::MileXamlControlsDemo::TreeViewItemModel>();

    };
}

namespace winrt::MileXamlControlsDemo::factory_implementation
{
    struct MainPage : MainPageT<MainPage, implementation::MainPage>
    {
    };
}
