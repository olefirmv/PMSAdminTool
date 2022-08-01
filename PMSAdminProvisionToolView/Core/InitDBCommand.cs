using PMSAdminProvisionTool.BL;
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
    public class InitDBCommand : ICommand
    {
        public InitDBCommand()
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
                GeneralCreator creator = new GeneralCreator();

                if (creator.CreateDBWithTable())
                {
                    MessageBox.Show("База данных успешно проинициализирована");
                }
                else
                {
                    MessageBox.Show("Ошибка во время создания базы данных");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "//" + ex.Source);
            }
            
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
