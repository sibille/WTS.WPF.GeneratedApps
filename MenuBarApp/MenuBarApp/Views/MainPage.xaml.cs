using System.Windows.Controls;

using MenuBarApp.ViewModels;

namespace MenuBarApp.Views
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
