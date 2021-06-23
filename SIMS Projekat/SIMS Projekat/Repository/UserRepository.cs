using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Model;

namespace SIMS_Projekat.Repository
{
    class UserRepository : Repository<User>
    {
        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity user in ModelContext.Instance.Users)
            {
                if (((User)user).Name.Contains(term) || ((User)user).Surname.Contains(term))
                {
                    result.Add(user);
                }
            }

            return result;
        }



        public List<Entity> GetAllForUserType(EnumTypeOfUser userType)
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity user in ModelContext.Instance.Users)
            {
                userType = EnumTypeOfUser.Patient;
                if (((User)user).TypeUser == userType)
                {
                    result.Add(user);
                }
            }

            return result;
        }

        public IEnumerable<Entity> SortByName(EnumTypeOfUser userType)
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity user in ModelContext.Instance.Users)
            {
                userType = EnumTypeOfUser.Patient;
                if (((User)user).TypeUser == userType)
                {
                    result.Add(user);

                }
            }
            return result.OrderBy(x => ((User)x).Name);
        }

        public IEnumerable<Entity> SortBySurname(EnumTypeOfUser userType)
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity user in ModelContext.Instance.Users)
            {
                userType = EnumTypeOfUser.Patient;
                if (((User)user).TypeUser == userType)
                {
                    result.Add(user);

                }
            }
            return result.OrderBy(x => ((User)x).Surname);
            
        }

        public string GetPharmacist()
        {
            User user2 = new User();
            foreach(User user in ModelContext.Instance.Users)
            {
                if(user.TypeUser == EnumTypeOfUser.Pharmacist)
                {
                    user2 = user;

                }
            
            }
            return user2.Name;
        }





    }
}

