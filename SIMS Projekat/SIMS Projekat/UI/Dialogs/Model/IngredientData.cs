using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;

namespace SIMS_Projekat.UI.Dialogs.Model
{
    public class IngredientData : Entity
    {
        private int frequency;

        public int Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

      
        public override void InitExportList()
        {
            throw new NotImplementedException();
        }

        public override string Validate(string columnName)
        {
            throw new NotImplementedException();
        }
    }
}
