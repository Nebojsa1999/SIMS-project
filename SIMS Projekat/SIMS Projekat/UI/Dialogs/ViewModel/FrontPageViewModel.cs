using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using SIMS_Projekat.UI.Dialogs.Model;
using SIMS_Projekat.UI.Dialogs.View;

namespace SIMS_Projekat.UI.Dialogs.ViewModel
{
    public class FrontPageViewModel : BaseDialogViewModel
    {

        public FrontPageViewModel(FrontPageView view) : base(view, typeof(Ingredient))
        {
            Init();

        }

        protected override void Init()
        {
        }





    }
}
