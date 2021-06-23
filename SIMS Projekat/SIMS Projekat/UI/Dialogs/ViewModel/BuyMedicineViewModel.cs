using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SIMS_Projekat.CompositeCommon;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using SIMS_Projekat.UI.Dialogs.Model;
using SIMS_Projekat.UI.Dialogs.View;

namespace SIMS_Projekat.UI.Dialogs.ViewModel
{
    public class BuyMedicineViewModel : ViewModelBase
    {
        private MedicineViewModel medicine;
        private int quantity;
        private BuyMedicine view;
        private RelayCommand acceptCommand;

        public BuyMedicineViewModel( BuyMedicine view, MedicineViewModel medicine) 
        {
            this.view = view;
            this.medicine = medicine;

        }

        
        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                this.quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public RelayCommand AcceptCommand
        {
            get
            {
                return acceptCommand ?? (acceptCommand = new RelayCommand(param => this.AcceptCommandExecute()));
            }
        }

        protected void AcceptCommandExecute()
        {
            if(Quantity>5 || Quantity==0)
            {
                MessageBox.Show("Select number greater than 0 and not higher than 5");
            }

            else
            {
                medicine.SelectedQuanity = Quantity;
                view.Close();
            }
        }

     





    }
}
