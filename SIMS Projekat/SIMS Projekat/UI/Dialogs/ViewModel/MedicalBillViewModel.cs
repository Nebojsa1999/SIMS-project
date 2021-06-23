using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.CompositeCommon;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using SIMS_Projekat.Service;
using SIMS_Projekat.UI.Dialogs.Model;
using SIMS_Projekat.UI.Dialogs.View;

namespace SIMS_Projekat.UI.Dialogs.ViewModel
{
    public class MedicalBillViewModel : BaseDialogViewModel
    {
        private MedicalBillService service = new MedicalBillService();
        private RelayCommand logoutCommand;


        public MedicalBillViewModel(MedicalBillView view) : base(view, typeof(MedicalBill))
        {
            Init();
        }

        protected override void Init()
        {
            Items = new ObservableCollection<Entity>(service.GetAllForPatientService(ModelContext.Instance.User));
        }

        public ObservableCollection<TableData> BillMedicine
        {
            get
            {
                ObservableCollection<TableData> tableData = new ObservableCollection<TableData>();

                if (SelectedItem == null || ((MedicalBill)SelectedItem).MedicineAndAmount == null)
                {
                    return tableData;
                }

                foreach (KeyValuePair<Medicine, int> pair in ((MedicalBill)SelectedItem).MedicineAndAmount)
                {
                    
                    tableData.Add(new TableData() { Name = pair.Key.Name, Amount = pair.Value, Cost = pair.Key.Cost});
                    
                }

                return tableData;
            }

        }

        public override Entity SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                    OnPropertyChanged(nameof(BillMedicine));
                }
            }
        }

        protected override void OkCommandExecute()
        {
            base.OkCommandExecute();

            ModelContext.Instance.Bills = new List<Entity>(Items);
            service.SaveService();
            Init();
        }

        protected override Entity OkAfterAddDatabase()
        {
            MedicalBill bill = SelectedItem as MedicalBill;
            bill.User = ModelContext.Instance.User;
            return SelectedItem;
        }

        protected override Entity OkAfterEditDatabase()
        {
            service.SaveService();
            return SelectedItem;
        }

        protected override bool DatabaseRemove(Entity item)
        {
            service.RemoveService(item);
            service.SaveService();
            return true;
        }

        public RelayCommand BackCommand
        {
            get
            {
                return logoutCommand ?? (logoutCommand = new RelayCommand(param => LogOutCommandExecute()));
            }
        }

        public void LogOutCommandExecute()
        {

            CloseAction(); // closes the window

        }

        public Action CloseAction { get; set; }

        protected override void DoSearch()
        {
            Items = new ObservableCollection<Entity>(service.SearchService  (Search));
        }
    }
}
