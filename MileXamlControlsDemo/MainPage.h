#pragma once

#include "MainPage.g.h"

namespace winrt::MileXamlControlsDemo::implementation
{
    struct MainPage : MainPageT<MainPage>
    {
        MainPage() = default;

        void InitializeComponent();

        int32_t MyProperty();
        void MyProperty(int32_t value);

        void ClickHandler(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args);
    };
}

namespace winrt::MileXamlControlsDemo::factory_implementation
{
    struct MainPage : MainPageT<MainPage, implementation::MainPage>
    {
    };
}
