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
using SIMS_Projekat.Service;
using SIMS_Projekat.UI.Dialogs.Model;
using SIMS_Projekat.UI.Dialogs.View;

namespace SIMS_Projekat.UI.Dialogs.ViewModel
{
    public class IngredientViewModel : BaseDialogViewModel
    {
        private IngredientService service = new IngredientService();
        private RelayCommand logoutCommand;
        private RelayCommand searchByNameCommand;
        private RelayCommand searchByDescriptionCommand;
        private RelayCommand searchByMedicineCommand;
        private RelayCommand sortIngredientsFrequencyCommand;
        private RelayCommand sortByNameCommand;
        private string nameSearch;
        private string descriptionSearch;
        private string medicineSearch;
        private int frequency;
        public string NameSearch
        {
            get
            {
                return nameSearch;
            }

            set
            {
                this.nameSearch = value;
            }
        }

        public string DescriptionSearch
        {
            get
            {
                return descriptionSearch;
            }

            set
            {
                this.descriptionSearch = value;
            }
        }

        public string MedicineSearch
        {
            get
            {
                return medicineSearch;
            }

            set
            {
                this.medicineSearch = value;
            }
        }

        public int Frequency
        {
            get
            {
                return frequency;
            }

            set
            {
                this.frequency = value;
                OnPropertyChanged(nameof(Frequency));
            }
        }

   


        public IngredientViewModel(IngredientView view) : base(view, typeof(Ingredient))
        {
            Init();

        }

        protected override void Init()
        {
            Items = new ObservableCollection<Entity>(service.GetAllService());
        }

        protected override void OkCommandExecute()
        {
            base.OkCommandExecute();

            ModelContext.Instance.Ingredients = new List<Entity>(Items);
            service.SaveService();
            Init();
        }

        protected override Entity OkAfterAddDatabase()
        {
            Ingredient ingredientSelect = SelectedItem as Ingredient;
            foreach (Ingredient ingredient in ModelContext.Instance.Ingredients)
            {
                if (ingredientSelect.Name == ingredient.Name)
                {
                    MessageBox.Show("Ingredient with that name already exists!");
                    SelectedItem = null;
                }

            }
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


        public RelayCommand SortByNameCommand
        {
            get
            {
                return sortByNameCommand ?? (sortByNameCommand = new RelayCommand(param => this.SortByNameCommandExecute()));
            }
        }

        public void SortByNameCommandExecute()
        {
            Items = new ObservableCollection<Entity>(service.SortByNameService());

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


        public RelayCommand SortIngredientsFrequencyCommand
        {
            get
            {
                return sortIngredientsFrequencyCommand ?? (sortIngredientsFrequencyCommand = new RelayCommand(param => this.SortCommandMedicineExecute()));
            }
        }

        public void SortCommandMedicineExecute()
        {
            Items = new ObservableCollection<Entity>(service.SortByMedicineService());

        }

        public ObservableCollection<IngredientData> MedicamentIngredient
        {
            get
            {

                ObservableCollection<IngredientData> tableData = new ObservableCollection<IngredientData>();
                if (SelectedItem == null)
                {
                    return tableData;
                }
               
                    tableData.Add(new IngredientData() { Frequency = service.CountInMedicamentService(SelectedItem as Ingredient) });
                
                 return tableData;
            }
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
            Items = new ObservableCollection<Entity>(service.SearchService(Search));
        }

        public RelayCommand SearchByNameCommand
        {
            get
            {
                return searchByNameCommand ?? (searchByNameCommand = new RelayCommand(param => this.SearchNameExecute()));
            }
        }

        public RelayCommand SearchByDedcriptionCommand
        {
            get
            {
                return searchByDescriptionCommand ?? (searchByDescriptionCommand = new RelayCommand(param => this.SearchDescriptionExecute()));
            }
        }

        public RelayCommand SearchByMedicineCommand
        {
            get
            {
                return searchByMedicineCommand ?? (searchByMedicineCommand = new RelayCommand(param => this.SearchMedicineExecute()));
            }
        }

        public void SearchNameExecute()
        {
            Items = new ObservableCollection<Entity>(service.SearchByNameService(NameSearch));

        }

        public void SearchDescriptionExecute()
        {
            Items = new ObservableCollection<Entity>(service.SearchByDescriptionService(DescriptionSearch));

        }

        public void SearchMedicineExecute()
        {
            Items = new ObservableCollection<Entity>(service.SearchByMedicineService(MedicineSearch));

        }


    }
}
