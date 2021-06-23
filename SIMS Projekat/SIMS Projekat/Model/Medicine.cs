using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Medicine : Entity
    {
        private string name;
        private string producer;
        private float cost;
        private int amount;
        private Dictionary<Ingredient, double> ingredients;
        private bool? accepted;
        private bool deleted;
        private User user;
        private string reason;


        public Medicine() 
        {
            ID = ModelContext.Instance.IDGenerator(ModelContext.Instance.Medicines).ToString();
            Ingredients = new Dictionary<Ingredient, double>();
            Accepted = null;
        }

        public User User
        {
            get
            {
                return user;
            }

            set
            {
                this.user = value;
            }
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

        public string Producer
        {
            get
            {
                return producer;
            }

            set
            {
                this.producer = value;
            }
        }

        public float Cost
        {
            get
            {
                return cost;
            }

            set
            {
                this.cost = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                this.amount = value;
            }
        }

        public Dictionary<Ingredient, double> Ingredients
        {
            get
            {
                return ingredients;
            }

            set
            {
                this.ingredients = value;
            }


        }

        public bool? Accepted
        {
            get
            {
                return accepted;
            }
            set
            {
                this.accepted = value;
                OnPropertyChanged(nameof(Accepted));

            }
        }

        public bool Deleted
        {
            get
            {
                return deleted;
            }
            set
            {
                this.deleted = value;
                OnPropertyChanged(nameof(Deleted));
            }
        }


        public string Reason
        {
            get
            {
                return reason;
            }

            set
            {
                this.reason = value;
                OnPropertyChanged(nameof(Reason));


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
