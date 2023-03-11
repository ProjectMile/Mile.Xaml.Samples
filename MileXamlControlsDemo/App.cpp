#include "pch.h"

#include "App.h"
#include "MainPage.h"

using namespace winrt;
using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Navigation;
using namespace MileXamlControlsDemo;
using namespace MileXamlControlsDemo::implementation;

#include <Mile.Xaml.h>

namespace winrt::MileXamlControlsDemo::implementation
{
    App::App()
    {
        ::MileXamlGlobalInitialize();
    }

    void App::Close()
    {
        Exit();
        ::MileXamlGlobalUninitialize();
    }
}
