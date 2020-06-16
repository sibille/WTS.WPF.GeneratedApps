using System;
using System.Windows.Input;

using MenuBarApp.Helpers;

namespace MenuBarApp.ViewModels
{
    public class ShellDialogViewModel : Observable
    {
        private ICommand _closeCommand;

        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand(OnClose));

        public Action<bool?> SetResult { get; set; }

        public ShellDialogViewModel()
        {
        }

        private void OnClose()
        {
            bool result = true;
            SetResult(result);
        }
    }
}
