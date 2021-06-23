using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{

    public class User : Entity
    {
        private string userID;
        private string email;
        private string password;
        private string name;
        private string surname;
        private string mobilePhone;
        private EnumTypeOfUser typeUser;

        public User()
        {
            ID = ModelContext.Instance.IDGenerator(ModelContext.Instance.Users).ToString();

        }

        public string UserID
        {
            get
            {
                return userID;
            }

            set
            {
                this.userID = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                this.email = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;

            }
            set
            {
                this.surname = value;
            }
        }
        public string MobilePhone
        {
            get
            {
                return mobilePhone;

            }
            set
            {
                this.mobilePhone = value;
            }
        }
        public EnumTypeOfUser TypeUser
        {

            get
            {
                return typeUser;
            }

            set
            {
                this.typeUser = value;
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
