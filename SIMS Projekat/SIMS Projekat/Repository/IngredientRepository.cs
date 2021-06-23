using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;

namespace SIMS_Projekat.Repository
{
    public class IngredientRepository : Repository<Ingredient> 

    {

        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity ingredient in ModelContext.Instance.Ingredients)
            {
                if (((Ingredient)ingredient).Name.Contains(term) || ((Ingredient)ingredient).ID.Contains(term))
                {
                    result.Add(ingredient);
                }
            }

            return result;
        }

        public IEnumerable<Entity> SearchByName(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity ingredient in ModelContext.Instance.Ingredients)
            {

                if (((Ingredient)ingredient).Name.Contains(term) || ((Ingredient)ingredient).Name.ToLower().Contains(term.ToLower()) || ((Ingredient)ingredient).Name.ToUpper().Contains(term.ToUpper()))
                {
                    result.Add(ingredient);
                }

            }

            return result;
        }

        public IEnumerable<Entity> SearchByDescription(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity ingredient in ModelContext.Instance.Ingredients)
            {

                if (((Ingredient)ingredient).Description.Contains(term) || ((Ingredient)ingredient).Description.ToLower().Contains(term.ToLower()) || ((Ingredient)ingredient).Description.ToUpper().Contains(term.ToUpper()))
                {
                    result.Add(ingredient);
                }

            }

            return result;
        }

        public IEnumerable<Entity> SearchByMedicine(string term = "")
        {
            string[] terms = term.Split(',');
            List<Entity> result = new List<Entity>();
            foreach(Entity ingredient in ModelContext.Instance.Ingredients)
            {
                bool found = false;
                    if (found)
                    {
                        break;
                    }

                foreach (string t in terms)
                {
                    if (IngredientInMedication(ingredient as Ingredient, t))
                    {

                        result.Add(ingredient);
                        found = true;
                        break;
                    }
                }
            }

            return result;
        }

        public bool IngredientInMedication(Ingredient ingredient, string medicationName)
        {

            foreach (Medicine medication in ModelContext.Instance.Medicines)
            {
                if (medication.Name == medicationName)
                {
                    if (medication.Ingredients.ContainsKey(ingredient))
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public IEnumerable<Entity> SortByMedicine()
        {
            Dictionary<Ingredient, int> dic = new Dictionary<Ingredient, int>();


            foreach (Entity entity in ModelContext.Instance.Ingredients)
            {
                dic.Add(entity as Ingredient, CountInMedicament(entity as Ingredient));
            }

            List<Entity> result = new List<Entity>();

            foreach (var item in dic.OrderByDescending(value => value.Value))
            {
                result.Add(item.Key);
            }

            return result;
        }

        public IEnumerable<Entity> SortByName()
        {
            return ModelContext.Instance.Ingredients.OrderBy(x => ((Ingredient)x).Name);
        }

        public int CountInMedicament(Ingredient ingredient)
        {
            int count = 0;

            foreach (Medicine medication in ModelContext.Instance.Medicines)
            {
                if (medication.Ingredients.ContainsKey(ingredient))
                {
                    count++;
                }
            }

            return count;
        }

        


    }
}
