
using System;
using System.Windows;

using SIMS_Projekat.UI.Dialogs.ViewModel;

namespace SIMS_Projekat.UI.Dialogs.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();
            UserViewModel vm = new UserViewModel(this); // this creates an instance of the ViewModel
            this.DataContext = vm; // this sets the newly created ViewModel as the DataContext for the View
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }
    }
    
}

