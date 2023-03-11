#pragma once
#include "App.xaml.g.h"

namespace winrt::MileXamlControlsDemo::implementation
{
    class App : public AppT<App>
    {
    public:
        App();
        void Close();
    };
}
