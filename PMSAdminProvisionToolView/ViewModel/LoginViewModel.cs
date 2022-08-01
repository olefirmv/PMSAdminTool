using PMSAdminProvisionToolView.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PMSAdminProvisionToolView.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        public ICommand LoginCommand { get; }

        public MainViewModel _parent;

        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand();
        }

    }
}
