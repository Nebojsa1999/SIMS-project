using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;

namespace SIMS_Projekat.Repository
{
    class MedicalBillRepository : Repository<MedicalBill>
    {

        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicallbill in ModelContext.Instance.Bills)
            {
                if (((MedicalBill)medicallbill).ID.Contains(term) || ((MedicalBill)medicallbill).Pharmacist.Contains(term))
                {
                    result.Add(medicallbill);
                }
            }

            return result;
        }

        public IEnumerable<Entity> GetAllForPatient(User user)
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity bill in ModelContext.Instance.Bills)
            {
                if (((MedicalBill)bill).User != null && ((MedicalBill)bill).User.ID == user.ID && user.TypeUser == EnumTypeOfUser.Patient)
                {
                    result.Add(bill);

                }
            }


            return result;
        }

        public int GetAllBills()
        {
            int totalAmount = 0;
            foreach (Entity bill in ModelContext.Instance.Bills)
            {
                if(DateTime.Now >= ((MedicalBill)bill).Date.AddDays(-7))
                {
                   foreach(KeyValuePair<Medicine, int> ing in ((MedicalBill)bill).MedicineAndAmount)
                    {
                        totalAmount += ing.Value;
                    }
                }
            }
                return totalAmount;
        }

     

    }
}
