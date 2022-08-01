using PMSAdminProvisionToolView.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PMSAdminProvisionToolView.Core
{
    public class LoginCommand : ICommand
    {
        public LoginCommand()
        {

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is LoginViewModel)
            {
                LoginViewModel loginVM = parameter as LoginViewModel;
               
                if (loginVM.Login == "admin" && loginVM.Password == "pmsadmin")
                {
                    AdminViewModel adminViewModel = new AdminViewModel()
                    {
                        _parent = loginVM._parent
                    };

                    MainViewModel mainViewModel = loginVM._parent;
                    mainViewModel.AdminVM = adminViewModel;
                    mainViewModel.CurrentView = mainViewModel.AdminVM;
                }
            }

        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
