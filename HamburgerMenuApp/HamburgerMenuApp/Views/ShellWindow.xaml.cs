using System.Windows.Controls;

using HamburgerMenuApp.Contracts.Views;
using HamburgerMenuApp.ViewModels;

using MahApps.Metro.Controls;

namespace HamburgerMenuApp.Views
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

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();
    }
}
