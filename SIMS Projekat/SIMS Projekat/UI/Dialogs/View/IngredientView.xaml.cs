using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SIMS_Projekat.UI.Dialogs.ViewModel;

namespace SIMS_Projekat.UI.Dialogs.View
{
    /// <summary>
    /// Interaction logic for IngredientView.xaml
    /// </summary>
    public partial class IngredientView : Window
    {
        public IngredientView()
        {
            InitializeComponent();
            IngredientViewModel vm = new IngredientViewModel(this); // this creates an instance of the ViewModel
            this.DataContext = vm; // this sets the newly created ViewModel as the DataContext for the View
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

        }
    }
}
