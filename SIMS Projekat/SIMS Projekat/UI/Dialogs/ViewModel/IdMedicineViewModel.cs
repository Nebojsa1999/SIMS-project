using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.CompositeCommon;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using SIMS_Projekat.UI.Dialogs.Model;
using SIMS_Projekat.UI.Dialogs.View;

namespace SIMS_Projekat.UI.Dialogs.ViewModel
{
    public class IdMedicineViewModel : BaseDialogViewModel
    {
        private MedicneRepository medicineRepository = new MedicneRepository();
        private string iDMedicine;
        private RelayCommand acceptCommand;

        public string IDMedicine
        {
            get
            {
                return iDMedicine;
            }

            set
            {
                this.iDMedicine = value;
            }
        }


        public IdMedicineViewModel(IdMedicineView view) : base(view, typeof(Medicine))
        {
            Init();

        }

        protected override void Init()
        {
        }

        public RelayCommand AcceptCommand
        {
            get
            {
                return acceptCommand ?? (acceptCommand = new RelayCommand(param => AcceptCommandExecute()));
            }
        }


        protected void AcceptCommandExecute()
        {

        protected override Entity OkAfterAddDatabase()
        {
            return SelectedItem;
        }
       





    }
}
