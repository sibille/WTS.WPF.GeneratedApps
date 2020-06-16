using System.Windows.Controls;

using HamburgerMenuApp.ViewModels;

namespace HamburgerMenuApp.Views
{
    public partial class MasterDetailPage : Page
    {
        public MasterDetailPage(MasterDetailViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
