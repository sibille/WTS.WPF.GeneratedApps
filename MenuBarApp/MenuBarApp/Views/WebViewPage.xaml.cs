using System.Windows.Controls;

using MenuBarApp.ViewModels;

using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

namespace MenuBarApp.Views
{
    public partial class WebViewPage : Page
    {
        private readonly WebViewViewModel _viewModel;

        public WebViewPage(WebViewViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _viewModel = viewModel;
            _viewModel.Initialize(webView);
        }

        private void OnNavigationCompleted(object sender, WebViewControlNavigationCompletedEventArgs e)
            => _viewModel.OnNavigationCompleted(e);
    }
}
