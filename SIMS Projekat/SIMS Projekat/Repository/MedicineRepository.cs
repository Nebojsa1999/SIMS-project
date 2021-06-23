using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;

namespace SIMS_Projekat.Repository
{
    class MedicneRepository : Repository<Medicine>
    {
        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicne).Name.Contains(term))
                {
                    result.Add(medicne);
                }
            }

            return result;
        }

        public IEnumerable<Entity> SortByName()
        {
            return ModelContext.Instance.Medicines.OrderBy(x => ((Medicine)x).Name);
        }

        public IEnumerable<Entity> SortByPrice()
        {
            return ModelContext.Instance.Medicines.OrderByDescending(x => ((Medicine)x).Cost);
        }

        public IEnumerable<Entity> SortByAmount()
        {

            return ModelContext.Instance.Medicines.OrderByDescending(x => ((Medicine)x).Amount);
        }

        public IEnumerable<Entity> SortByNameDoctor()
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity medicine in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicine).Deleted == false)
                {
                    result.Add(medicine);

                }
            }
            return result.OrderBy(x => ((Medicine)x).Name);
        }

        public IEnumerable<Entity> SortByPriceDoctor()
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity medicine in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicine).Deleted == false)
                {
                    result.Add(medicine);

                }
            }
            return result.OrderByDescending(x => ((Medicine)x).Cost);
        }

        public IEnumerable<Entity> SortByAmountDoctor()
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity medicine in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicine).Deleted == false)
                {
                    result.Add(medicine);

                }
            }
            return result.OrderByDescending(x => ((Medicine)x).Amount);
        }

        public IEnumerable<Entity> SortByNamePatient()
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity medicine in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicine).Deleted == false && ((Medicine)medicine).Accepted == true)
                {
                    result.Add(medicine);

                }
            }
            return result.OrderBy(x => ((Medicine)x).Name);
        }

        public IEnumerable<Entity> SortByPricePatient()
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity medicine in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicine).Deleted == false && ((Medicine)medicine).Accepted == true)
                {
                    result.Add(medicine);

                }
            }
            return result.OrderByDescending(x => ((Medicine)x).Cost);
        }

        public IEnumerable<Entity> SortByAmountPatient()
        {

            List<Entity> result = new List<Entity>();

            foreach (Entity medicine in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicine).Deleted == false && ((Medicine)medicine).Accepted == true)
                {
                    result.Add(medicine);

                }
            }
            return result.OrderByDescending(x => ((Medicine)x).Amount);
        }


        public IEnumerable<Entity> SearchPrice(double priceFrom, double priceTo)
        {
            List<Entity> prices = new List<Entity>();

            foreach (Entity entity in ModelContext.Instance.Medicines)
            {

                if (((Medicine)entity).Cost >= priceFrom && ((Medicine)entity).Cost <= priceTo)
                {
                    prices.Add(entity);
                }
            }
            return prices;
        }

        public IEnumerable<Entity> SearchByIngredient(string term = "")
        {
            string[] terms = term.Split('|');
            List<Entity> result = new List<Entity>();
                foreach (Entity entity in ModelContext.Instance.Medicines)
                {
                    bool found = false;

                    foreach (KeyValuePair<Ingredient, double> pair in ((Medicine)entity).Ingredients)
                        {
                            if (found)
                            {
                                break;
                            }

                            foreach (string t in terms)
                            {
                                if (pair.Key.Name.Contains(t) || pair.Key.Name.ToLower().Contains(t.ToLower()) || pair.Key.Name.ToUpper().Contains(t.ToUpper()))
                                {
                                    result.Add(entity);
                                    found = true;
                                    break;
                                }
                            }
                    
                        }
                }
                
            return result;
        }

        public  IEnumerable<Entity> SearchByID(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {

                if (((Medicine)medicne).ID.Contains(term) || ((Medicine)medicne).ID.ToLower().Contains(term.ToLower()) || ((Medicine)medicne).ID.ToUpper().Contains(term.ToUpper()))
                {
                    result.Add(medicne);
                }
      
            }

            return result;
        }
        public  IEnumerable<Entity> SearchByName(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {


                if (((Medicine)medicne).Name.Contains(term) || ((Medicine)medicne).Name.ToLower().Contains(term.ToLower()) || ((Medicine)medicne).Name.ToUpper().Contains(term.ToUpper()))
                {
                    result.Add(medicne);
                }

                
            }

            return result;
        }
        public  IEnumerable<Entity> SearchByProducer(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {

                if (((Medicine)medicne).Producer.Contains(term) || ((Medicine)medicne).Producer.ToLower().Contains(term.ToLower()) || ((Medicine)medicne).Producer.ToUpper().Contains(term.ToUpper()))
                {
                    result.Add(medicne);
                }

              
            }

            return result;
        }
        public  IEnumerable<Entity> SearchByAmount(double amount)
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {

                if (((Medicine)medicne).Amount == amount)
                {
                    result.Add(medicne);
                }
            }

            return result;
        }

        public IEnumerable<Entity> SearchPriceDoctor(double priceFrom, double priceTo)
        {
            List<Entity> prices = new List<Entity>();

            foreach (Entity entity in ModelContext.Instance.Medicines)
            {
                if (((Medicine)entity).Deleted == false)
                {
                  if (((Medicine)entity).Cost >= priceFrom && ((Medicine)entity).Cost <= priceTo)
                    {
                        prices.Add(entity);
                    }

                }
            }
            return prices;
        }

        public IEnumerable<Entity> SearchByIngredientDoctor(string term = "")
        {
            string[] terms = term.Split('|');
            List<Entity> result = new List<Entity>();
            foreach (Entity entity in ModelContext.Instance.Medicines)
            {
                bool found = false;
                if (((Medicine)entity).Deleted == false)
                {
                    foreach (KeyValuePair<Ingredient, double> pair in ((Medicine)entity).Ingredients)
                    {
                        if (found)
                        {
                            break;
                        }

                        foreach (string t in terms)
                        {
                            if (pair.Key.Name.Contains(t) || pair.Key.Name.ToLower().Contains(t.ToLower()) || pair.Key.Name.ToUpper().Contains(t.ToUpper()))
                            {
                                result.Add(entity);
                                found = true;
                                break;
                            }
                        }

                    }
                }
            }

            return result;
        }

        public IEnumerable<Entity> SearchByIDDoctor(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicne).Deleted == false)
                { 

                    if (((Medicine)medicne).ID.Contains(term) || ((Medicine)medicne).ID.ToLower().Contains(term.ToLower()) || ((Medicine)medicne).ID.ToUpper().Contains(term.ToUpper()))
                    {
                        result.Add(medicne);
                    }
                }
            }

            return result;
        }
        public IEnumerable<Entity> SearchByNameDoctor(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {

                if (((Medicine)medicne).Deleted == false)
                { 
                    if (((Medicine)medicne).Name.Contains(term) || ((Medicine)medicne).Name.ToLower().Contains(term.ToLower()) || ((Medicine)medicne).Name.ToUpper().Contains(term.ToUpper()))
                    {
                        result.Add(medicne);
                    }
                }

            }

            return result;
        }
        public IEnumerable<Entity> SearchByProducerDoctor(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicne).Deleted == false)
                {
                    if (((Medicine)medicne).Producer.Contains(term) || ((Medicine)medicne).Producer.ToLower().Contains(term.ToLower()) || ((Medicine)medicne).Producer.ToUpper().Contains(term.ToUpper()))
                    {
                        result.Add(medicne);
                    }
                }


            }

            return result;
        }
        public IEnumerable<Entity> SearchByAmountDoctor(double amount)
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicne).Deleted == false)
                {

                    if (((Medicine)medicne).Amount == amount)
                    {
                        result.Add(medicne);
                    }
                }
            }

            return result;
        }

        public IEnumerable<Entity> SearchPricePatient(double priceFrom, double priceTo)
        {
            List<Entity> prices = new List<Entity>();

            foreach (Entity entity in ModelContext.Instance.Medicines)
            {
                if (((Medicine)entity).Deleted == false && ((Medicine)entity).Accepted == true)
                { 
                    if (((Medicine)entity).Cost >= priceFrom && ((Medicine)entity).Cost <= priceTo)
                    {
                        prices.Add(entity);
                    }
                }
            }
            return prices;
        }

        public IEnumerable<Entity> SearchByIngredientPatient(string term = "")
        {
            string[] terms = term.Split('|');
            List<Entity> result = new List<Entity>();
            foreach (Entity entity in ModelContext.Instance.Medicines)
            {
                if (((Medicine)entity).Deleted == false && ((Medicine)entity).Accepted == true)
                {
                    bool found = false;

                    foreach (KeyValuePair<Ingredient, double> pair in ((Medicine)entity).Ingredients)
                    {
                        if (found)
                        {
                            break;
                        }

                        foreach (string t in terms)
                        {
                            if (pair.Key.Name.Contains(t) || pair.Key.Name.ToLower().Contains(t.ToLower()) || pair.Key.Name.ToUpper().Contains(t.ToUpper()))
                            {
                                result.Add(entity);
                                found = true;
                                break;
                            }
                        }

                    }
                }
            }

            return result;
        }

        public IEnumerable<Entity> SearchByIDPatient(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicne).Deleted == false && ((Medicine)medicne).Accepted == true)
                {

                    if (((Medicine)medicne).ID.Contains(term) || ((Medicine)medicne).ID.ToLower().Contains(term.ToLower()) || ((Medicine)medicne).ID.ToUpper().Contains(term.ToUpper()))
                    {
                        result.Add(medicne);
                    }
                }
            }

            return result;
        }
        public IEnumerable<Entity> SearchByNamePatient(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {

                if (((Medicine)medicne).Deleted == false && ((Medicine)medicne).Accepted == true)
                {

                    if (((Medicine)medicne).Name.Contains(term) || ((Medicine)medicne).Name.ToLower().Contains(term.ToLower()) || ((Medicine)medicne).Name.ToUpper().Contains(term.ToUpper()))
                    {
                        result.Add(medicne);
                    }
                }


            }

            return result;
        }
        public IEnumerable<Entity> SearchByProducerPatient(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicne).Deleted == false && ((Medicine)medicne).Accepted == true)
                {

                    if (((Medicine)medicne).Producer.Contains(term) || ((Medicine)medicne).Producer.ToLower().Contains(term.ToLower()) || ((Medicine)medicne).Producer.ToUpper().Contains(term.ToUpper()))
                    {
                        result.Add(medicne);
                    }
                }


            }

            return result;
        }
        public IEnumerable<Entity> SearchByAmountPatient(double amount)
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity medicne in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicne).Deleted == false && ((Medicine)medicne).Accepted == true)
                {
                    if (((Medicine)medicne).Amount == amount)
                    {
                        result.Add(medicne);
                    }
                }
            }

            return result;
        }

        public List<Entity> GetAllForPatient(EnumTypeOfUser userType)
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity medicine in ModelContext.Instance.Medicines)
            {
                if(((Medicine)medicine).Deleted == false && ((Medicine)medicine).Accepted == true)
                {
                    result.Add(medicine);
                }
            }

            return result;
        }

        public List<Entity> GetAllForDoctor(EnumTypeOfUser userType)
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity medicine in ModelContext.Instance.Medicines)
            {
                if (((Medicine)medicine).Deleted == false)
                {
                    result.Add(medicine);
                }
            }

            return result;
        }



    }


}
