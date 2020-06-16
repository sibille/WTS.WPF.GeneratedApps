using System;
using System.Windows;
using System.Windows.Input;

using MenuBarApp.Contracts.Services;
using MenuBarApp.Helpers;
using MenuBarApp.Properties;

namespace MenuBarApp.ViewModels
{
    // You can show pages in different ways (update main view, navigate, right pane, new windows or dialog)
    // using the NavigationService, RightPaneService and WindowManagerService.
    // Read more about MenuBar project type here:
    // https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/WPF/projectTypes/menubar.md
    public class ShellViewModel : Observable
    {
        private readonly INavigationService _navigationService;
        private readonly IRightPaneService _rightPaneService;

        private RelayCommand _goBackCommand;
        private ICommand _menuFileSettingsCommand;
        private ICommand _menuViewsWebViewCommand;
        private ICommand _menuViewsMasterDetailCommand;
        private ICommand _menuViewsMainCommand;
        private ICommand _menuFileExitCommand;
        private ICommand _loadedCommand;
        private ICommand _unloadedCommand;

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ICommand MenuFileSettingsCommand => _menuFileSettingsCommand ?? (_menuFileSettingsCommand = new RelayCommand(OnMenuFileSettings));

        public ICommand MenuFileExitCommand => _menuFileExitCommand ?? (_menuFileExitCommand = new RelayCommand(OnMenuFileExit));

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));

        public ShellViewModel(INavigationService navigationService, IRightPaneService rightPaneService)
        {
            _navigationService = navigationService;
            _rightPaneService = rightPaneService;
        }

        private void OnLoaded()
        {
            _navigationService.Navigated += OnNavigated;
        }

        private void OnUnloaded()
        {
            _rightPaneService.CleanUp();
            _navigationService.Navigated -= OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void OnNavigated(object sender, string viewModelName)
        {
            GoBackCommand.OnCanExecuteChanged();
        }

        private void OnMenuFileExit()
            => Application.Current.Shutdown();

        public ICommand MenuViewsMainCommand => _menuViewsMainCommand ?? (_menuViewsMainCommand = new RelayCommand(OnMenuViewsMain));

        private void OnMenuViewsMain()
            => _navigationService.NavigateTo(typeof(MainViewModel).FullName, null, true);

        public ICommand MenuViewsMasterDetailCommand => _menuViewsMasterDetailCommand ?? (_menuViewsMasterDetailCommand = new RelayCommand(OnMenuViewsMasterDetail));

        private void OnMenuViewsMasterDetail()
            => _navigationService.NavigateTo(typeof(MasterDetailViewModel).FullName, null, true);

        public ICommand MenuViewsWebViewCommand => _menuViewsWebViewCommand ?? (_menuViewsWebViewCommand = new RelayCommand(OnMenuViewsWebView));

        private void OnMenuViewsWebView()
            => _navigationService.NavigateTo(typeof(WebViewViewModel).FullName, null, true);

        private void OnMenuFileSettings()
            => _rightPaneService.OpenInRightPane(typeof(SettingsViewModel).FullName);
    }
}
