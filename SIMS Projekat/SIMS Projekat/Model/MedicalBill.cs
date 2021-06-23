using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
   public class MedicalBill : Entity
    {
        private string pharmacist;
        private DateTime date;
        private Dictionary<Medicine, int> medicineAndAmount = new Dictionary<Medicine, int>();
        private float totalAmount;
        private User user;

        public MedicalBill()
        {
            ID = ModelContext.Instance.IDGenerator(ModelContext.Instance.Bills).ToString();
            Date = DateTime.Now;

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

        public string Pharmacist
        {
            get
            {
                return pharmacist;
            }
            set
            {
                this.pharmacist = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                this.date = value;
            }
        }
        public Dictionary<Medicine, int> MedicineAndAmount
        {
            get
            {
                return medicineAndAmount;
            }
            set
            {
                this.medicineAndAmount = value;
            }
        }
        public float TotalAmount
        {
            get
            {
                return totalAmount;

            }
            set
            {
                this.totalAmount = value;
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
