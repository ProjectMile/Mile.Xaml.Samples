#include <Windows.h>

#include "pch.h"

#include "App.h"
#include "MainPage.h"

#include <Mile.Xaml.h>

int WINAPI wWinMain(
    _In_ HINSTANCE hInstance,
    _In_opt_ HINSTANCE hPrevInstance,
    _In_ LPWSTR lpCmdLine,
    _In_ int nShowCmd)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    winrt::init_apartment(winrt::apartment_type::single_threaded);

    winrt::com_ptr<winrt::MileXamlControlsDemo::implementation::App> app =
        winrt::make_self<winrt::MileXamlControlsDemo::implementation::App>();

    winrt::MileXamlControlsDemo::MainPage XamlWindowContent =
        winrt::make<winrt::MileXamlControlsDemo::implementation::MainPage>();

    HWND WindowHandle = ::CreateWindowExW(
        WS_EX_CLIENTEDGE,
        L"Mile.Xaml.ContentWindow",
        L"MileXamlControlsDemo",
        WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT,
        0,
        CW_USEDEFAULT,
        0,
        nullptr,
        nullptr,
        hInstance,
        winrt::get_abi(XamlWindowContent));
    if (!WindowHandle)
    {
        return -1;
    }

    ::ShowWindow(WindowHandle, nShowCmd);
    ::UpdateWindow(WindowHandle);

    int Result = ::MileXamlContentWindowDefaultMessageLoop();

    app->Close();

    return Result;
}
