using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using SIMS_Projekat.UI.Components.Toolbar.ViewModel;

namespace SIMS_Projekat.UI.Components.Toolbar.View
{
    /// <summary>
    /// Interaction logic for Toolbar.xaml
    /// </summary>
    public partial class Toolbar : UserControl
    {
        public Toolbar()
        {
            InitializeComponent();

            ToolbarViewModel vm = new ToolbarViewModel(); // this creates an instance of the ViewModel
            this.DataContext = vm; // this sets the newly created ViewModel as the DataContext for the View
            if (vm.CloseAction == null)
            {

                vm.CloseAction = new Action(() => Window.GetWindow(this).Close());
            }
            
        }
    }
}
