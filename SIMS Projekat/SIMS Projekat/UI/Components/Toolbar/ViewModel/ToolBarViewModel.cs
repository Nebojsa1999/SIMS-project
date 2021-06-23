using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SIMS_Projekat.CompositeCommon;
using SIMS_Projekat.Model;
using SIMS_Projekat.UI.Dialogs.View;

namespace SIMS_Projekat.UI.Components.Toolbar.ViewModel
{
    public class ToolbarViewModel : ViewModelBase
    {
        private RelayCommand medicineCommand;
        private RelayCommand billCommand;
        private RelayCommand ingredientCommand;
        private RelayCommand userCommand;
        private RelayCommand logoutCommand;

   

        public RelayCommand MedicineCommand
        {
            get
            {
                return medicineCommand ?? (medicineCommand = new RelayCommand(param => MedicineCommandExecute()));
            }
        }

        public RelayCommand UserCommand
        {
            get
            {
                return userCommand ?? (userCommand = new RelayCommand(param => UserCommandExecute()));
            }
        }


        public RelayCommand BillCommand
        {
            get
            {
                return billCommand ?? (billCommand = new RelayCommand(param => BillCommandExecute()));
            }
        }

        public RelayCommand IngredientCommand
        {
            get
            {
                return ingredientCommand ?? (ingredientCommand = new RelayCommand(param => IngredientCommandExecute()));
            }
        }

        public RelayCommand LogOutCommand
        {
            get
            {
                return logoutCommand ?? (logoutCommand = new RelayCommand(param => LogOutCommandExecute()));
            }
        }


        public Visibility IsBillVisable
        {
            get
            {
                if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Patient)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

        public Visibility IsUserVisable
        {
            get
            {
                if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

        public void LogOutCommandExecute()
        {

            CloseAction(); // closes the window
            MainWindow main = new MainWindow();
            main.ShowDialog();

        }

        public Action CloseAction { get; set; }

        public void MedicineCommandExecute()
        {
            MedicineView view = new MedicineView();
            view.ShowDialog();
        }

        public void BillCommandExecute()
        {
            MedicalBillView view = new MedicalBillView();
            view.ShowDialog();
        }

        public void UserCommandExecute()
        {
            UserView view = new UserView();
            view.ShowDialog();
        }

        public void IngredientCommandExecute()
        {
            IngredientView view = new IngredientView();
            view.ShowDialog();
        }
    }
}
