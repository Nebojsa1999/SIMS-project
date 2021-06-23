using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Repository;

namespace SIMS_Projekat.Model
{
    class ModelContext
    {
        private static ModelContext instance;
        private List<Entity> users = new List<Entity>();
        private List<Entity> medicines = new List<Entity>();
        private List<Entity> bills = new List<Entity>();
        private List<Entity> ingredients = new List<Entity>();
        private User user;

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

        public List<Entity> Users
        {
            get
            {
                return users;
            }

            set
            {
                this.users = value;
            }
        }

        public List<Entity> Medicines
        {
            get
            {
                return medicines;
            }

            set
            {
                this.medicines = value;
            }
        }

        public List<Entity> Bills
        {
            get
            {
                return bills;
            }

            set
            {
                this.bills = value;
            }
        }

        public List<Entity> Ingredients
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


        public ModelContext()
        {
            
        }

        public static ModelContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModelContext();
                    instance.Load();
                }

                return instance;
            }
        }

        public void Load()
        {
            LoadUsers();
            LoadIngredients();
            LoadMedicines();
            LoadBills();
         
        }

       public  int IDGenerator(List<Entity> entities) {
		int id = 0;
		
		foreach(Entity entity in entities)
		{
			if(int.Parse(entity.ID) > id)
			{
				id = int.Parse(entity.ID);
			}
		}
		return id + 1;
	}


        public void LoadUsers()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("users.txt"))
            {
                users = result;
                return;
            }

            StreamReader reader = new StreamReader("users.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');

                User user = new User();
                user.ID = data[0];
                user.Email = data[1];
                user.Password = data[2];
                user.Name = data[3];
                user.Surname = data[4];
                user.MobilePhone = data[5];
                user.TypeUser = GetUserType(data[6]);
                user.UserID = data[7];
                result.Add(user);
            }

            users = result;

        }
        public void LoadBills()
        {

            List<Entity> result = new List<Entity>();
            if (!File.Exists("bills.txt"))
            {
                bills = result;
                return;
            }

            StreamReader reader = new StreamReader("bills.txt");
            string line;
            UserRepository userRepository = new UserRepository();
            MedicneRepository medicineRepository = new MedicneRepository();


            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');

                MedicalBill bill = new MedicalBill();
                bill.ID = data[0];
                bill.Pharmacist = data[1];
                bill.Date = DateTime.Parse(data[2]);
                bill.TotalAmount = float.Parse(data[3]);
                bill.User = (User)userRepository.Get(data[4]);

                string[] medicines = data[5].Split(',');
                foreach (string ing in medicines)
                {
                    string[] ingData = ing.Split(';');

                    if (ingData.Length < 2)
                    {
                        continue;
                    }

                    bill.MedicineAndAmount.Add((Medicine)medicineRepository.Get(ingData[0]), int.Parse(ingData[1]));
                }

                result.Add(bill);
            }

            bills = result;

        }
        public void LoadMedicines()
        {

            List<Entity> result = new List<Entity>();
            if (!File.Exists("medicines.txt"))
            {
                medicines = result;
                return;
            }

            StreamReader reader = new StreamReader("medicines.txt");
            string line;
            IngredientRepository ingredientRepository = new IngredientRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');

                Medicine medicine = new Medicine();
                medicine.ID = data[0];
                medicine.Name = data[1];
                medicine.Producer = data[2];
                medicine.Cost = float.Parse(data[3]);
                medicine.Amount = int.Parse(data[4]);
                medicine.Accepted = bool.Parse(data[5]);
                medicine.Deleted = bool.Parse(data[6]);
                medicine.Reason = data[7];

                string[] ingredients = data[8].Split(',');

                foreach (string ing in ingredients) 
                {
                    string[] ingData = ing.Split(';');

                    if (ingData.Length < 2) 
                    {
                        continue;
                    }

                    medicine.Ingredients.Add((Ingredient)ingredientRepository.Get(ingData[0]), double.Parse(ingData[1]));
                }


                result.Add(medicine);
            }

            medicines = result;

        }
        public void LoadIngredients()
        {

            List<Entity> result = new List<Entity>();
            if (!File.Exists("ingredients.txt"))
            {
                ingredients = result;
                return;
            }

            StreamReader reader = new StreamReader("ingredients.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');

                Ingredient ingredient = new Ingredient();
                ingredient.ID = data[0];
                ingredient.Name = data[1];
                ingredient.Description = data[2];
                result.Add(ingredient);
            }

            ingredients = result;

        }

        public void Save()
        {
            SaveUsers();
            SaveBills();
            SaveMedicines();
            SaveIngredients();
        }

        public void SaveUsers()
        {
            if (users == null)
            {
                return;
            }

            using (StreamWriter file = new StreamWriter("users.txt"))
            {
                foreach (Entity entity in users)
                {
                    string line = string.Empty;
                    line += ((User)entity).ID + "|";
                    line += ((User)entity).Email + "|";
                    line += ((User)entity).Password + "|";
                    line += ((User)entity).Name + "|";
                    line += ((User)entity).Surname + "|";
                    line += ((User)entity).MobilePhone + "|";
                    line += ((User)entity).TypeUser + "|";
                    line += ((User)entity).UserID + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }
        public void SaveBills()
        {
            if (bills == null)
            {
                return;
            }

            using (StreamWriter file = new StreamWriter("bills.txt"))
            {
                foreach (Entity entity in bills)
                {
                    string line = string.Empty;
                    line += ((MedicalBill)entity).ID + "|";
                    line += ((MedicalBill)entity).Pharmacist + "|";
                    line += ((MedicalBill)entity).Date + "|";
                    line += ((MedicalBill)entity).TotalAmount + "|";
                    line += ((MedicalBill)entity).User.ID + "|";
                    foreach (KeyValuePair<Medicine, int> ing in ((MedicalBill)entity).MedicineAndAmount)
                    {
                        line += ing.Key.ID + ";" + ing.Value + ",";
                    }



                    file.WriteLine(line);
                }
                file.Close();

            }
        }
        public void SaveMedicines()
        {
            if (medicines == null)
            {
                return;
            }

            using (StreamWriter file = new StreamWriter("medicines.txt"))
            {
                foreach (Entity entity in medicines)
                {
                    string line = string.Empty;
                    line += ((Medicine)entity).ID + "|";
                    line += ((Medicine)entity).Name + "|";
                    line += ((Medicine)entity).Producer + "|";
                    line += ((Medicine)entity).Cost + "|";
                    line += ((Medicine)entity).Amount + "|";
                    line += ((Medicine)entity).Accepted + "|";
                    line += ((Medicine)entity).Deleted + "|";
                    line += ((Medicine)entity).Reason + "|";

                    foreach (KeyValuePair<Ingredient, double> ing in ((Medicine)entity).Ingredients) 
                    {
                        line +=  ing.Key.ID + ";" +  ing.Value + ",";
                    }


                    file.WriteLine(line);
                }
                file.Close();

            }
        }
        public void SaveIngredients()
        {
            if (ingredients == null)
            {
                return;
            }

            using (StreamWriter file = new StreamWriter("ingredients.txt"))
            {
                foreach (Entity entity in ingredients)
                {
                    string line = string.Empty;
                    line += ((Ingredient)entity).ID + "|";
                    line += ((Ingredient)entity).Name + "|";
                    line += ((Ingredient)entity).Description + "|";


                    file.WriteLine(line);
                }
                file.Close();

            }
        }

        public List<Entity> Get(Type type)
        {
            if (type == typeof(Medicine))
            {
                return Medicines;
            }

            if (type == typeof(Ingredient))
            {
                return Ingredients;
            }

            if (type == typeof(MedicalBill))
            {
                return Bills;
            }

            return Users;

        }

        public void Set(Type type, List<Entity> entities)
        {
            if (type == typeof(Medicine))
            {
                Medicines = entities;
                return;
            }
            if (type == typeof(MedicalBill))
            {
                Bills = entities;
                return;
            }
            if (type == typeof(Ingredient))
            {
                Ingredients = entities;
                return;
            }

            Users = entities;
        }

        public EnumTypeOfUser GetUserType(string type)
        {
            if (type == "Doctor") { return EnumTypeOfUser.Doctor; }
            else if (type == "Patient") { return EnumTypeOfUser.Patient; }

            return EnumTypeOfUser.Pharmacist;
        }
    }
}
