using PMSAdminProvisionTool.BL.DataBase;
using PMSAdminProvisionTool.BL.Model;
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
    public class AddEmployeeCommand : ICommand
    {
        public AddEmployeeCommand()
        {

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            try
            {
                if (parameter is AdminViewModel)
                {
                    AdminViewModel adminVM = parameter as AdminViewModel;

                    Credential credential = new Credential(adminVM.Login, adminVM.Password);
                    CredentialDB credentialDB = new CredentialDB();
                    credentialDB.InsertMethod(credential);

                    Employee employee = new Employee(adminVM.Name, adminVM.SecondName, adminVM.Patronymic, adminVM.Email, adminVM.Login);
                    EmployeeDB employeeDB = new EmployeeDB();
                    employeeDB.InsertMethod(employee);

                    MessageBox.Show("Пользователь добавлен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source+"/"+ex.Message, "Ошибка создания пользователя");
            }
            
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
