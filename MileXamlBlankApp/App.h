#pragma once
#include "App.xaml.g.h"

#include <Windows.h>

namespace winrt::MileXamlBlankApp::implementation
{
    class App : public AppT<App>
    {
    public:
        App();
        void Close();
    };
}
