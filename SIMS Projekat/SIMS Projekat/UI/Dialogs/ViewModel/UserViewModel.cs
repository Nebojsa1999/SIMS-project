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
    public class UserViewModel : BaseDialogViewModel
    {
        private UserService service = new UserService();
        private List<ComboData<EnumTypeOfUser>> userTypes = new List<ComboData<EnumTypeOfUser>>();
        private RelayCommand logoutCommand;
        private RelayCommand sortByNameCommand;
        private RelayCommand sortBySurnameCommand;




        public UserViewModel(UserView view) : base(view, typeof(User))
        {
            Init();

            userTypes.Add(new ComboData<EnumTypeOfUser>() { Name = "Patient", Value = EnumTypeOfUser.Patient });
        }

        protected override void Init()
        {
            Items = new ObservableCollection<Entity>(service.GetAllService());
            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                Items = new ObservableCollection<Entity>(service.GetAllForUserTypeService(EnumTypeOfUser.Patient));
            }

        }

        protected override bool OkAfterAdd()
        {

            if (OkAfterAddDatabase() == null)
            {
                return false;
            }

            ModelContext.Instance.Users.Add(SelectedItem);
            return true;
        }

        protected override void AddCommandExecute()
        {
            SelectedItem = GetInstance();

            if (ModelContext.Instance.User.TypeUser == EnumTypeOfUser.Doctor)
            {
                ((User)SelectedItem).TypeUser = EnumTypeOfUser.Patient;
            }

            DialogState = CompositeCommon.Enums.DialogState.Add;
        }

        protected override void OkCommandExecute()
        {
            base.OkCommandExecute();

            service.SaveService();
            Init();
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
                Items = new ObservableCollection<Entity>(service.SortByNameService(EnumTypeOfUser.Patient));

        }
        public RelayCommand SortBySurnameCommand
        {
            get
            {
                return sortBySurnameCommand ?? (sortBySurnameCommand = new RelayCommand(param => this.SortBySurnameCommandExecute()));
            }
        }

        public void SortBySurnameCommandExecute()
        {
            Items = new ObservableCollection<Entity>(service.SortBySurnameService(EnumTypeOfUser.Patient));
            
        }

        protected override Entity OkAfterAddDatabase()
        {
            User userSelect = SelectedItem as User;
            foreach (User user in ModelContext.Instance.Users)
            {
                if (userSelect.Email == user.Email || user.UserID == userSelect.UserID)
                {
                    MessageBox.Show("User with that User ID or email already exists!");
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

        protected override void DoSearch()
        {
            Items = new ObservableCollection<Entity>(service.SearchService(Search));
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


        public List<ComboData<EnumTypeOfUser>> UserTypes
        {
            get
            {
                return userTypes;
            }

            set
            {
                this.userTypes = value;
            }
        }
    }
}
