using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;

namespace SIMS_Projekat.Service
{
    public class UserService
    {
        private UserRepository userReposiotry = new UserRepository();

        public void AddService(Entity entity)
        {
            userReposiotry.Add(entity);
        }

        public Entity GetService(string id)
        {
            return userReposiotry.Get(id);
        }

        public IEnumerable<Entity> GetAllService()
        {
            return userReposiotry.GetAll();
        }

        public void RemoveService(Entity entity)
        {
            userReposiotry.Remove(entity);
        }
        public void SaveService()
        {
            userReposiotry.Save();
        }

        public  IEnumerable<Entity> SearchService(string term = "")
        {
            return userReposiotry.Search(term);
        }

        public List<Entity> GetAllForUserTypeService(EnumTypeOfUser userType)
        {
            return userReposiotry.GetAllForUserType(userType);
        }

        public IEnumerable<Entity> SortByNameService(EnumTypeOfUser userType)
        {
            return userReposiotry.SortByName(userType);
        }

        public IEnumerable<Entity> SortBySurnameService(EnumTypeOfUser userType)
        {
            return userReposiotry.SortBySurname(userType);
        }

        public string GetPharmacistService()
        {
            return userReposiotry.GetPharmacist();
        }


    }
}
