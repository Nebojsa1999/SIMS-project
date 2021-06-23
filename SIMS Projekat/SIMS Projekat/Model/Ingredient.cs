using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Ingredient : Entity
    {

        private string name;
        private string description;

        public Ingredient()
        {
            ID = ModelContext.Instance.IDGenerator(ModelContext.Instance.Ingredients).ToString();

        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                this.description = value;
            }
        }

        public override void InitExportList()
        {

        }

        public override string Validate(string columnName)
        {
            return "";

        }
    }
}
