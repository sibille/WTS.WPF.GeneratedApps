using System.Windows;
using System.Windows.Input;

using MahApps.Metro.Controls;

using MenuBarApp.Contracts.Services;
using MenuBarApp.Contracts.ViewModels;
using MenuBarApp.Helpers;

using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;

namespace MenuBarApp.ViewModels
{
    public class WebViewViewModel : Observable, INavigationAware
    {
        // TODO WTS: Set the URI of the page to show by default
        private const string DefaultUrl = "https://docs.microsoft.com/windows/apps/";
        private readonly IRightPaneService _rightPaneService;

        private readonly ISystemService _systemService;

        private string _source;
        private bool _isLoading = true;
        private bool _isShowingFailedMessage = false;
        private Visibility _isLoadingVisibility = Visibility.Visible;
        private Visibility _failedMesageVisibility = Visibility.Collapsed;
        private ICommand _refreshCommand;
        private RelayCommand _browserBackCommand;
        private RelayCommand _browserForwardCommand;
        private ICommand _openInBrowserCommand;
        private WebView _webView;

        public string Source
        {
            get { return _source; }
            set { Set(ref _source, value); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                Set(ref _isLoading, value);
                IsLoadingVisibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public bool IsShowingFailedMessage
        {
            get => _isShowingFailedMessage;
            set
            {
                Set(ref _isShowingFailedMessage, value);
                FailedMesageVisibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility IsLoadingVisibility
        {
            get { return _isLoadingVisibility; }
            set { Set(ref _isLoadingVisibility, value); }
        }

        public Visibility FailedMesageVisibility
        {
            get { return _failedMesageVisibility; }
            set { Set(ref _failedMesageVisibility, value); }
        }

        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new RelayCommand(OnRefresh));

        public RelayCommand BrowserBackCommand => _browserBackCommand ?? (_browserBackCommand = new RelayCommand(() => _webView?.GoBack(), () => _webView?.CanGoBack ?? false));

        public RelayCommand BrowserForwardCommand => _browserForwardCommand ?? (_browserForwardCommand = new RelayCommand(() => _webView?.GoForward(), () => _webView?.CanGoForward ?? false));

        public ICommand OpenInBrowserCommand => _openInBrowserCommand ?? (_openInBrowserCommand = new RelayCommand(OnOpenInBrowser));

        public WebViewViewModel(ISystemService systemService, IRightPaneService rightPaneService)
        {
            _systemService = systemService;
            Source = DefaultUrl;
            _rightPaneService = rightPaneService;
        }

        public void Initialize(WebView webView)
        {
            _webView = webView;
        }

        public void OnNavigationCompleted(WebViewControlNavigationCompletedEventArgs e)
        {
            IsLoading = false;
            if (e != null && !e.IsSuccess)
            {
                // Use `e.WebErrorStatus` to vary the displayed message based on the error reason
                IsShowingFailedMessage = true;
            }

            BrowserBackCommand.OnCanExecuteChanged();
            BrowserForwardCommand.OnCanExecuteChanged();
        }

        private void OnRefresh()
        {
            IsShowingFailedMessage = false;
            IsLoading = true;
            _webView?.Refresh();
        }

        private void OnOpenInBrowser()
            => _systemService.OpenInWebBrowser(Source);

        public void OnNavigatedTo(object parameter)
        {
            _rightPaneService.PaneOpened += OnRightPaneOpened;
            _rightPaneService.PaneClosed += OnRightPaneClosed;
        }

        public void OnNavigatedFrom()
        {
            _rightPaneService.PaneOpened -= OnRightPaneOpened;
            _rightPaneService.PaneClosed -= OnRightPaneClosed;
        }

        private void OnRightPaneOpened(object sender, System.EventArgs e)
        {
            // WebView control is always rendered on top
            // We need to adapt the WebView to be able to show the right pane
            if (sender is SplitView splitView)
            {
                _webView.Margin = new Thickness(0, 0, splitView.OpenPaneLength, 0);
            }
        }

        private void OnRightPaneClosed(object sender, System.EventArgs e)
         => _webView.Margin = new Thickness(0);
    }
}
