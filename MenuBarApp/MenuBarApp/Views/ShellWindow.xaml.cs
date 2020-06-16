using System.Windows.Controls;

using MahApps.Metro.Controls;

using MenuBarApp.Contracts.Views;
using MenuBarApp.ViewModels;

namespace MenuBarApp.Views
{
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        public ShellWindow(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public Frame GetRightPaneFrame()
            => rightPaneFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();

        public SplitView GetSplitView()
            => splitView;
    }
}
