using PMSAdminProvisionToolView.Core;
using System.Windows.Input;

namespace PMSAdminProvisionToolView.ViewModel
{
    public class AdminViewModel : ObservableObject
    {
        public ICommand InitDBCommand { get; }
        public ICommand AddEmployeeCommand { get; }

        public MainViewModel _parent;

        private string _connectionString;
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
                OnPropertyChanged(nameof(ConnectionString));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _secondName;
        public string SecondName
        {
            get
            {
                return _secondName;
            }
            set
            {
                _secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }
        private string _patronymic;
        public string Patronymic
        {
            get
            {
                return _patronymic;
            }
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
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

        public AdminViewModel()
        {
            InitDBCommand      = new InitDBCommand();
            AddEmployeeCommand = new AddEmployeeCommand();
        }
    }
}
