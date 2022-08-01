using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSAdminProvisionToolView.Core;

namespace PMSAdminProvisionToolView.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public AdminViewModel AdminVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            LoginViewModel LoginVM = new LoginViewModel()
            {
                _parent = this
            };

            CurrentView = LoginVM;
        }
    }
}
