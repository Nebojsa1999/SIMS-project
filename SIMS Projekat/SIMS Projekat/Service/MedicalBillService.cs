using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;

namespace SIMS_Projekat.Service
{
    public class MedicalBillService
    {
        private MedicalBillRepository medicalBillRepositroy = new MedicalBillRepository();

        public void AddService(Entity entity)
        {
            medicalBillRepositroy.Add(entity);
        }

        public Entity GetService(string id)
        {
            return medicalBillRepositroy.Get(id);
        }

        public IEnumerable<Entity> GetAllService()
        {
            return medicalBillRepositroy.GetAll();
        }

        public void RemoveService(Entity entity)
        {
            medicalBillRepositroy.Remove(entity);
        }
        public void SaveService()
        {
            medicalBillRepositroy.Save();
        }

        public  IEnumerable<Entity> SearchService(string term = "")
        {
            return medicalBillRepositroy.Search(term);
        }

        public IEnumerable<Entity> GetAllForPatientService(User user)
        {
            return medicalBillRepositroy.GetAllForPatient(user);
        }

        public int GetAllBillsService()
        {
            return medicalBillRepositroy.GetAllBills();
        }








    }
}
