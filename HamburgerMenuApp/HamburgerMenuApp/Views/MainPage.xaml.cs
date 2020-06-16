using System.Windows.Controls;

using HamburgerMenuApp.ViewModels;

namespace HamburgerMenuApp.Views
{
    public partial class MainPage : Page
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
