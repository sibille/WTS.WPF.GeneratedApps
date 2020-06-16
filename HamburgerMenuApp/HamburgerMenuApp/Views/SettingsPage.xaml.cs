using System.Windows.Controls;

using HamburgerMenuApp.ViewModels;

namespace HamburgerMenuApp.Views
{
    public partial class SettingsPage : Page
    {
        public SettingsPage(SettingsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
