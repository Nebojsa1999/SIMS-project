using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Repository;
using SIMS_Projekat.Model;
using System.Collections.ObjectModel;
using SIMS_Projekat.UI.Dialogs.View;
using SIMS_Projekat.UI.Dialogs.Model;
using SIMS_Projekat.CompositeCommon;
using System.Windows;
using SIMS_Projekat.Service;

namespace SIMS_Projekat.UI.Dialogs.ViewModel
{

    public class MedicineViewModel : BaseDialogViewModel
    {
        #region Fields
        private MedicineService service = new MedicineService();
        private MedicalBillService serviceBill = new MedicalBillService();
        private UserService serviceUser = new UserService();
        private List<ComboData<Ingredient>> ingredientsCombo = new List<ComboData<Ingredient>>();
        private Ingredient selectedIngredient;
        private double quantity = 0 ;
        private RelayCommand addIngredient;
        private RelayCommand searchByPriceCommand;
        private RelayCommand searchByID;
        private RelayCommand searchByName;
        private RelayCommand searchByAmount;
        private RelayCommand searchByProducer;
        private RelayCommand searchByIngredient;
        private RelayCommand logoutCommand;
        private RelayCommand sortByNameCommand;
        private RelayCommand sortByAmountCommand;
        private RelayCommand sortByPriceCommand;
        private RelayCommand logicDeleteCommand;
        private RelayCommand acceptCommand;
        private RelayCommand declineCommand;
        private RelayCommand buyCommand;
        private RelayCommand confirmCommand;
        private double priceFrom;
        private double priceTo;
        private string ingredientInMedicine;
        private string iDInMedicine;
        private int amountInMedicine;
        private string producerInMedicine;
        private string nameInMedicine;
        private string idMedicne;
        private string reasonTextBox;
        private int selectedQuantity;
        private MedicalBill selectedBill = new MedicalBill();
        #endregion Fields


        #region Constructor
        public MedicineViewModel(MedicineView view) : base(view, typeof(Medicine))
        {
            Init();
            LoadIngredient();
        }
        #endregion

        #region Command Properties
        public RelayCommand AddIngredient
        {
            get
            {
                return addIngredient ?? (addIngredient = new RelayCommand(param => this.AddIngredientExecute(), param => this.AddIngredientCanExecute()));
            }
        }
        public RelayCommand LogicDeleteCommand
        {
            get
            {
                return logicDeleteCommand ?? (logicDeleteCommand = new RelayCommand(param => this.LogicDeleteExecute()));
            }
        }

        public RelayCommand AcceptCommand
        {
            get
            {
                return acceptCommand ?? (acceptCommand = new RelayCommand(param => this.AcceptExecute(), param => this.AcceptCanExecute()));
            }
        }

        public RelayCommand BuyCommand
        {
            get
            {
                return buyCommand ?? (buyCommand = new RelayCommand(param => this.BuyExecute(), param => this.BuyCanExecute()));
            }
        }

        public RelayCommand DeclineCommand
        {
            get
            {
                return declineCommand ?? (declineCommand = new RelayCommand(param => this.DeclineExecute(), param => this.DeclineCanExecute()));
            }
        }


        public RelayCommand SearchByPriceCommand
        {
            get
            {
                return searchByPriceCommand ?? (searchByPriceCommand = new RelayCommand(param => this.SearchPriceExecute(), param => this.SearchPriceCanExecute()));
            }
        }
        public RelayCommand SearchByIngredient
        {
            get
            {
                return searchByIngredient ?? (searchByIngredient = new RelayCommand(param => this.SearchIngredientExecute()));
            }
        }
        public RelayCommand SearchByID
        {
            get
            {
                return searchByID ?? (searchByID = new RelayCommand(param => this.SearchIDExecute()));
            }
        }
        public RelayCommand SearchByName
        {
            get
            {
                return searchByName ?? (searchByName = new RelayCommand(param => this.SearchNameExecute()));
            }
        }
        public RelayCommand SearchByAmount
        {
            get
            {
                return searchByAmount ?? (searchByAmount = new RelayCommand(param => this.SearchAmountExecute()));
            }
        }
        public RelayCommand SearchByProducer
        {
            get
            {
                return searchByProducer ?? (searchByProducer = new RelayCommand(param => this.SearchProducerExecute()));
            }
        }
        public RelayCommand SortByNameCommand
        {
            get
            {
                return sortByNameCommand ?? (sortByNameCommand = new RelayCommand(param => this.SortByNameCommandExecute()));
            }
        }

        public RelayCommand SortByAmountCommand
        {
            get
            {
                return sortByAmountCommand ?? (sortByAmountCommand = new RelayCommand(param => this.SortByAmountCommandExecude()));
            }
        }
        public RelayCommand SortByPriceCommand
        {
            get
            {
                return sortByPriceCommand ?? (sortByPriceCommand = new RelayCommand(param => this.SortByPriceCommandExecute()));
            }
        }


        public RelayCommand BackCommand
        {
            get
            {
                return logoutCommand ?? (logoutCommand = new RelayCommand(param => LogOutCommandExecute()));
            }
        }


        public RelayCommand  ConfirmCommand
        {
            get
            {
                return confirmCommand ?? (confirmCommand = new RelayCommand(param => ConfirmCommandExecute()));
            }
        }

        #endregion

        #region Properties


        public Ingredient SelectedIngredient
        {
            get
            {
                return selectedIngredient;
            }

            set
            {
                this.selectedIngredient = value;
                OnPropertyChanged(nameof(SelectedIngredient));

            }
        }


        public string IngredientInMedicine
        {
            get
            {
                return ingredientInMedicine;
            }

            set
            {
                this.ingredientInMedicine = value;
            }
        }

        public string IDInMedicine
        {
            get
            {
                return iDInMedicine;
            }

            set
            {
                this.iDInMedicine = value;
            }
        }

        public int AmountInMedicine
        {
            get
            {
                return amountInMedicine;
            }

            set
            {
                this.amountInMedicine = value;
            }
        }

        public string ProducerInMedicine
        {
            get
            {
                return producerInMedicine;
            }

            set
            {
                this.producerInMedicine = value;
            }
        }

        public string IDMedicine
        {
            get
            {
                return idMedicne;
            }

            set
            {
                this.idMedicne = value;
            }
        }

        public string NameInMedicine
        {
            get
            {
                return nameInMedicine;
            }

            set
            {
                this.nameInMedicine = value;
            }
        }

        public string ReasonTextBox
        {
            get
            {
                return reasonTextBox;
            }

            set
            {
                this.reasonTextBox = value;
            }
        }


        public double Quantity
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

        public double PriceFrom
        {
            get
            {
                return priceFrom;
            }

            set
            {
                this.priceFrom = value;
                OnPropertyChanged(nameof(PriceFrom));

            }
        }

        public double PriceTo
        {
            get
            {
                return priceTo;
            }

            set
            {
                this.priceTo = value;
                OnPropertyChanged(nameof(PriceTo));

            }
        }

        public int SelectedQuanity
        {
            get
            {
                return selectedQuantity;
            }

            set
            {
                this.selectedQuantity = value;
            }
        }


        public MedicalBill SelectedBill
        {
            get
            {
                return selectedBill;
            }
            set
            {
                this.selectedBill = value; 
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
                    OnPropertyChanged(nameof(MedicamentIngredient));
                }
            }
        }
        public Action CloseAction { get; set; }


        public List<ComboData<Ingredient>> IngredientsCombo
        {
            get
            {
                return ingredientsCombo;
            }

            set
            {
                this.ingredientsCombo = value;
            }
        }

        public Visibility IsUserOrDoctor
        {
            get
            {
                if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor || ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Patient)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public Visibility OnlyDoctorStackPanel
        {
            get
            {
                if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist || ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Patient)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }


        public Visibility PatientVisibility
        {
            get
            {
                if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist || ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }




        public ObservableCollection<TableData> MedicamentIngredient 
        {
            get 
            {
                ObservableCollection<TableData> tableData = new ObservableCollection<TableData>();

                if (SelectedItem == null || ((Medicine)SelectedItem).Ingredients == null) 
                {
                    return tableData;
                }

                foreach (KeyValuePair<Ingredient, double> pair in ((Medicine)SelectedItem).Ingredients) 
                {
                    tableData.Add(new TableData() { Name = pair.Key.Name, Quantity = pair.Value });
                }

                return tableData;
            }

        }


    

        #endregion

        #region Command Methods


        public void LoadIngredient()
        {
            foreach (Ingredient ingredient in ModelContext.Instance.Ingredients)
            {
                ingredientsCombo.Add(new ComboData<Ingredient>() { Name = ingredient.Name , Value = ingredient });
            }
        }


        protected override void Init()
         {
            Items = new ObservableCollection<Entity>(service.GetAllService());
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Patient)
            {
                Items = new ObservableCollection<Entity>(service.GetAllForPatientService(EnumTypeOfUser.Patient));
            }
            else if(ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.GetAllForDoctorService(EnumTypeOfUser.Doctor));

            }
        }

        public void SearchPriceExecute()
        {
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist)
            {
                Items = new ObservableCollection<Entity>(service.SearchPriceService(priceFrom, priceTo));

            }

            else if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.SearchPriceDoctorService(priceFrom, priceTo));

            }

            else
            {
                Items = new ObservableCollection<Entity>(service.SearchPricePatientService(priceFrom, priceTo));

            }
        }

        public bool SearchPriceCanExecute()
        {
            return priceTo != priceFrom && priceTo > priceFrom;
        }

        public void SearchIngredientExecute()
        {
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist)
            {
                Items = new ObservableCollection<Entity>(service.SearchByIngredientService(IngredientInMedicine));

            }

            else if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.SearchByIngredientDoctorService(IngredientInMedicine));

            }

            else
            {
                Items = new ObservableCollection<Entity>(service.SearchByIngredientPatientService(IngredientInMedicine));

            }

        }
        public void SearchNameExecute()
        {
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist)
            {
                Items = new ObservableCollection<Entity>(service.SearchByNameService(NameInMedicine));

            }

            else if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.SearchByNameDoctorService(NameInMedicine));

            }

            else
            {
                Items = new ObservableCollection<Entity>(service.SearchByNamePatientService(NameInMedicine));

            }

        }
        public void SearchIDExecute()
        {
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist)
            {
                Items = new ObservableCollection<Entity>(service.SearchByIDService(IDInMedicine));

            }

            else if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.SearchByIDDoctorService(IDInMedicine));

            }

            else
            {
                Items = new ObservableCollection<Entity>(service.SearchByIDPatientService(IDInMedicine));

            }

        }
        public void SearchAmountExecute()
        {
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist)
            {
                Items = new ObservableCollection<Entity>(service.SearchByAmountService(AmountInMedicine));

            }

            else if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.SearchByAmountDoctorService(AmountInMedicine));

            }

            else
            {
                Items = new ObservableCollection<Entity>(service.SearchByAmountPatientService(AmountInMedicine));

            }

        }
        public void SearchProducerExecute()
        {
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist)
            {
                Items = new ObservableCollection<Entity>(service.SearchByProducerService(ProducerInMedicine));

            }

            else if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.SearchByProducerDoctorService(ProducerInMedicine));

            }

            else
            {
                Items = new ObservableCollection<Entity>(service.SearchByProducerPatientService(ProducerInMedicine));

            }

        }


        public void SortByNameCommandExecute()
        {
            if(ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist)
            {
                Items = new ObservableCollection<Entity>(service.SortByNameService());

            }

            else if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.SortByNameDoctorService());

            }

            else 
            {
                Items = new ObservableCollection<Entity>(service.SortByNamePatientService());

            }

        }
        public void SortByAmountCommandExecude()
        {
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist)
            {
                Items = new ObservableCollection<Entity>(service.SortByAmountService());

            }

            else if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.SortByAmountDoctorService());

            }

            else
            {
                Items = new ObservableCollection<Entity>(service.SortByAmountPatientService());

            }

        }


        public void SortByPriceCommandExecute()
        {
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Pharmacist)
            {
                Items = new ObservableCollection<Entity>(service.SortByPriceService());

            }

            else if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.SortByPriceDoctorService());

            }

            else
            {
                Items = new ObservableCollection<Entity>(service.SortByPricePatientService());

            }
        }

        public void AddIngredientExecute()
        {
            if (((Medicine)SelectedItem).Ingredients.ContainsKey(SelectedIngredient))
            {
                ((Medicine)SelectedItem).Ingredients[SelectedIngredient] =  Quantity;
            }
            else 
            {
                ((Medicine)SelectedItem).Ingredients.Add(SelectedIngredient, Quantity);
            }

            OnPropertyChanged(nameof(MedicamentIngredient));
            service.SaveService();

        }

        public bool AddIngredientCanExecute()
        {
            return SelectedItem != null;

        }

        public void LogicDeleteExecute()
        {
            bool isTrue = false;
            foreach(Entity entity in ModelContext.Instance.Medicines)
            {
                if(((Medicine)entity).ID == IDMedicine)
                {
                     isTrue = true;
                    ((Medicine)entity).Deleted = true;
                    service.SaveService();
                    MessageBox.Show("Medicine deleted");
                    break;
                }             
            }

            if(isTrue == false)
            {
                MessageBox.Show("Wrong medicine id");
            }
        }

        public void AcceptExecute()
        {
            Medicine medicine = SelectedItem as Medicine;
            medicine.Accepted = true;
            medicine.Reason = "";
            service.SaveService();
        }

        public bool AcceptCanExecute()
        {
            return SelectedItem != null;

        }


        public void BuyExecute()
        {
            BuyMedicine buyView = new BuyMedicine();
            buyView.DataContext =  new BuyMedicineViewModel(buyView,this);
            buyView.ShowDialog();
            Medicine medicine = SelectedItem as Medicine;
            
             

            if ((SelectedBill).MedicineAndAmount.ContainsKey(medicine))
            {
                ((SelectedBill).MedicineAndAmount[medicine]) = SelectedQuanity;
            }

            else
            {
                SelectedBill.MedicineAndAmount.Add(medicine, SelectedQuanity);
            }

            SelectedBill.TotalAmount += medicine.Cost * SelectedQuanity;
            SelectedBill.Pharmacist = serviceUser.GetPharmacistService();
            SelectedBill.User = ModelContext.Instance.User;
            medicine.Amount = medicine.Amount - SelectedQuanity;
        }


        public bool BuyCanExecute()
        {
            return SelectedItem != null;

        }

        public void ConfirmCommandExecute()
        {
           

                    if ( serviceBill.GetAllBillsService()<50)
                    {

                        ModelContext.Instance.Bills.Add(SelectedBill);
                        serviceBill.SaveService();
                        service.SaveService();
                        SelectedBill = new MedicalBill();
                    }
                
            
        }

        public void DeclineExecute()
        {
            Medicine medicine = SelectedItem as Medicine;
            medicine.Accepted = false;
            serviceBill.SaveService();
            service.SaveService();
        }

        public bool DeclineCanExecute()
        {
            return SelectedItem != null;

        }

        protected override void OkCommandExecute()
        {
            base.OkCommandExecute();

            ModelContext.Instance.Medicines = new List<Entity>(Items);
            service.SaveService();
            Init();
        }

        protected override Entity OkAfterAddDatabase()
        {
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

        protected override void DoSearch()
        {
            Items = new ObservableCollection<Entity>(service.SearchService(Search));
        }


        public void LogOutCommandExecute()
        {

            CloseAction(); // closes the window

        }

        #endregion

    }

}
