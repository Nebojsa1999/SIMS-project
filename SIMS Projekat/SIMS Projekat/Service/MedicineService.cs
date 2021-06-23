using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;

namespace SIMS_Projekat.Service
{
    public class MedicineService
    {
        private MedicneRepository medicineRepository = new MedicneRepository();

        public void AddService(Entity entity)
        {
            medicineRepository.Add(entity);
        }

        public Entity GetService(string id)
        {
            return medicineRepository.Get(id);
        }

        public IEnumerable<Entity> GetAllService()
        {
            return medicineRepository.GetAll();
        }

        public void RemoveService(Entity entity)
        {
            medicineRepository.Remove(entity);
        }

        public void SaveService()
        {
            medicineRepository.Save();
        }

        public IEnumerable<Entity> SearchService(string term = "")
        {
            return medicineRepository.Search(term);
        }

        public IEnumerable<Entity> SortByNameService()
        {
            return medicineRepository.SortByName();
        }

        public IEnumerable<Entity> SortByPriceService()
        {
            return medicineRepository.SortByPrice();
        }

        public IEnumerable<Entity> SortByAmountService()
        {
            return medicineRepository.SortByAmount();
        }

        public IEnumerable<Entity> SortByNameDoctorService()
        {
            return medicineRepository.SortByNameDoctor();
        }

        public IEnumerable<Entity> SortByPriceDoctorService()
        {
            return medicineRepository.SortByPriceDoctor();
        }

        public IEnumerable<Entity> SortByAmountDoctorService()
        {
            return medicineRepository.SortByAmountDoctor();
        }

        public IEnumerable<Entity> SortByNamePatientService()
        {
            return medicineRepository.SortByNamePatient();
        }

        public IEnumerable<Entity> SortByPricePatientService()
        {
            return medicineRepository.SortByPricePatient();
        }

        public IEnumerable<Entity> SortByAmountPatientService()
        {
            return medicineRepository.SortByAmountPatient();
        }

        public IEnumerable<Entity> SearchPriceService(double priceFrom, double priceTo)
        {
            return medicineRepository.SearchPrice(priceFrom, priceTo);
        }

        public IEnumerable<Entity> SearchByIngredientService(string term = "")
        {
            return medicineRepository.SearchByIngredient(term);
        }

        public IEnumerable<Entity> SearchByIDService(string term = "")
        {
            return medicineRepository.SearchByID(term);
        }

        public IEnumerable<Entity> SearchByNameService(string term = "")
        {
            return medicineRepository.SearchByName(term);
        }

        public IEnumerable<Entity> SearchByProducerService(string term = "")
        {
            return medicineRepository.SearchByProducer(term);
        }

        public IEnumerable<Entity> SearchByAmountService(double amount)
        {
            return medicineRepository.SearchByAmount(amount);
        }

        public IEnumerable<Entity> SearchPriceDoctorService(double priceFrom, double priceTo)
        {
            return medicineRepository.SearchPriceDoctor(priceFrom, priceTo);
        }

        public IEnumerable<Entity> SearchByIngredientDoctorService(string term = "")
        {
            return medicineRepository.SearchByIngredientDoctor(term);
        }

        public IEnumerable<Entity> SearchByIDDoctorService(string term = "")
        {
            return medicineRepository.SearchByIDDoctor(term);
        }

        public IEnumerable<Entity> SearchByNameDoctorService(string term = "")
        {
            return medicineRepository.SearchByNameDoctor(term);
        }

        public IEnumerable<Entity> SearchByProducerDoctorService(string term = "")
        {
            return medicineRepository.SearchByProducerDoctor(term);

        }

        public IEnumerable<Entity> SearchByAmountDoctorService(double amount)
        {
            return medicineRepository.SearchByAmountDoctor(amount);

        }


        public IEnumerable<Entity> SearchPricePatientService(double priceFrom, double priceTo)
        {
            return medicineRepository.SearchPricePatient(priceFrom, priceTo);
        }

        public IEnumerable<Entity> SearchByIngredientPatientService(string term = "")
        {
            return medicineRepository.SearchByIngredientPatient(term);
        }

        public IEnumerable<Entity> SearchByIDPatientService(string term = "")
        {
            return medicineRepository.SearchByIDPatient(term);
        }

        public IEnumerable<Entity> SearchByNamePatientService(string term = "")
        {
            return medicineRepository.SearchByNamePatient(term);
        }

        public IEnumerable<Entity> SearchByProducerPatientService(string term = "")
        {
            return medicineRepository.SearchByProducerPatient(term);

        }

        public IEnumerable<Entity> SearchByAmountPatientService(double amount)
        {
            return medicineRepository.SearchByAmountPatient(amount);

        }

        public List<Entity> GetAllForPatientService(EnumTypeOfUser userType)
        {
            return medicineRepository.GetAllForPatient(userType);
        }

        public List<Entity> GetAllForDoctorService(EnumTypeOfUser userType)
        {
            return medicineRepository.GetAllForDoctor(userType);

        }











    }
}
