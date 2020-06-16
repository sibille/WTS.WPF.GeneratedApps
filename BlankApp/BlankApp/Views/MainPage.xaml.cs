using System.Windows.Controls;

using BlankApp.ViewModels;

namespace BlankApp.Views
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
