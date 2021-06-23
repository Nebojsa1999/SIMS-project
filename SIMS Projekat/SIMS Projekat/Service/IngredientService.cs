using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;

namespace SIMS_Projekat.Service
{

    public class IngredientService
    {
        private IngredientRepository ingredientRepository = new IngredientRepository();

        public IEnumerable<Entity> SortByMedicineService()
        {
            return ingredientRepository.SortByMedicine();
        }

        public IEnumerable<Entity> SortByNameService()
        {
            return ingredientRepository.SortByName();
        }

        public int CountInMedicamentService(Ingredient ingredient)
        {
            return ingredientRepository.CountInMedicament(ingredient);
        }

        public bool IngredientInMedicationService(Ingredient ingredient, string medicationName)
        {
            return ingredientRepository.IngredientInMedication(ingredient,medicationName);

        }

        public IEnumerable<Entity> SearchByMedicineService(string term = "")
        {
            return ingredientRepository.SearchByMedicine(term);
        }

        public IEnumerable<Entity> SearchByDescriptionService(string term = "")
        {
            return ingredientRepository.SearchByDescription(term);
        }

        public IEnumerable<Entity> SearchByNameService(string term = "")
        {
            return ingredientRepository.SearchByName(term);
        }

        public IEnumerable<Entity> SearchService(string term = "")
        {
            return ingredientRepository.Search(term);

        }

        public void AddService(Entity entity)
        {
            ingredientRepository.Add(entity);
        }

        public Entity GetService(string id)
        {
            return ingredientRepository.Get(id);
        }

        public IEnumerable<Entity> GetAllService()
        {
            return ingredientRepository.GetAll();
        }

        public void RemoveService(Entity entity)
        {
            ingredientRepository.Remove(entity);
        }
        public void SaveService()
        {
            ingredientRepository.Save();
        }


    }
}
