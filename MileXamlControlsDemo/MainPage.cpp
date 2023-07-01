#include "pch.h"
#include "MainPage.h"
#include "MainPage.g.cpp"

#include "winrt/Windows.Media.Core.h"
#include "winrt/Windows.UI.Xaml.Controls.h"
#include "winrt/Windows.System.h"

#include "TreeViewItemModel.h"

using namespace winrt;
using namespace Windows::UI::Xaml;

namespace winrt::MileXamlControlsDemo::implementation
{
    void MainPage::InitializeComponent()
    {
        MainPageT::InitializeComponent();
        winrt::Windows::Foundation::Uri mediaUri(L"C:\\Windows\\SystemResources\\Windows.UI.SettingsAppThreshold\\SystemSettings\\Assets\\SDRSample.mkv");
        MediaPlayer().Source(winrt::Windows::Media::Core::MediaSource::CreateFromUri(mediaUri));
        inkToolbar().TargetInkCanvas(inkCanvasDemo());

        winrt::MileXamlControlsDemo::TreeViewItemModel rootNode1 = winrt::make<winrt::MileXamlControlsDemo::implementation::TreeViewItemModel>();
        rootNode1.Name(L"TreeView Root Node 1");
        rootNode1.IsSelected(true);
        _treeViewDataList.Append(rootNode1);

        winrt::MileXamlControlsDemo::TreeViewItemModel childNode1 = winrt::make<winrt::MileXamlControlsDemo::implementation::TreeViewItemModel>();
        childNode1.Name(L"TreeView child Node 1");
        childNode1.IsSelected(false);
        rootNode1.ChildrenNode().Append(childNode1);

        winrt::MileXamlControlsDemo::TreeViewItemModel childNode2 = winrt::make<winrt::MileXamlControlsDemo::implementation::TreeViewItemModel>();
        childNode2.Name(L"TreeView child Node 2");
        childNode2.IsSelected(false);
        rootNode1.ChildrenNode().Append(childNode2);

        winrt::MileXamlControlsDemo::TreeViewItemModel childNode3 = winrt::make<winrt::MileXamlControlsDemo::implementation::TreeViewItemModel>();
        childNode3.Name(L"TreeView child Node 3");
        childNode3.IsSelected(false);
        rootNode1.ChildrenNode().Append(childNode3);

        winrt::MileXamlControlsDemo::TreeViewItemModel rootNode2 = winrt::make<winrt::MileXamlControlsDemo::implementation::TreeViewItemModel>();
        rootNode2.Name(L"TreeView Root Node 2");
        rootNode2.IsSelected(false);
        _treeViewDataList.Append(rootNode2);

        winrt::MileXamlControlsDemo::TreeViewItemModel childNode4 = winrt::make<winrt::MileXamlControlsDemo::implementation::TreeViewItemModel>();
        childNode4.Name(L"TreeView child Node 4");
        childNode4.IsSelected(false);
        rootNode2.ChildrenNode().Append(childNode4);

        winrt::MileXamlControlsDemo::TreeViewItemModel childNode5 = winrt::make<winrt::MileXamlControlsDemo::implementation::TreeViewItemModel>();
        childNode5.Name(L"TreeView child Node 5");
        childNode5.IsSelected(false);
        rootNode2.ChildrenNode().Append(childNode5);
    }

    void MainPage::HyperlinkButton_Click(Windows::Foundation::IInspectable const& /* sender */, Windows::UI::Xaml::RoutedEventArgs const& /* args */)
    {
        winrt::Windows::Foundation::Uri vp9LinkUri(L"ms-windows-store://pdp/?productid=9N4D0MSMP0PT");
        winrt::Windows::System::Launcher::LaunchUriAsync(vp9LinkUri);
    }

    void MainPage::HyperlinkButton_Click1(Windows::Foundation::IInspectable const& /* sender */, Windows::UI::Xaml::RoutedEventArgs const& /* args */)
    {
        winrt::Windows::Foundation::Uri vp9LinkUri(L"https://learn.microsoft.com/en-us/answers/questions/635070/(ver-10-0-19041-0)-c-winrt-treeview-nodes-not-prop?childtoview=635698");
        winrt::Windows::System::Launcher::LaunchUriAsync(vp9LinkUri);
    }

    winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> MainPage::TreeViewDataList()
    {
        return _treeViewDataList;
    }

    void MainPage::TreeViewDataList(winrt::Windows::Foundation::Collections::IObservableVector<winrt::MileXamlControlsDemo::TreeViewItemModel> value)
    {
        _treeViewDataList = value;
    }
}
