using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SIMS_Projekat.CompositeCommon;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using SIMS_Projekat.UI.Dialogs.Model;
using SIMS_Projekat.UI.Dialogs.View;

namespace SIMS_Projekat.UI.Dialogs.ViewModel
{
    public class MainWindowViewModel : BaseDialogViewModel
    {
        private RelayCommand openFrontPage;
        private string userName;
        private string password;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                this.userName = value;
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

        public MainWindowViewModel(MainWindow view) : base(view, typeof(Ingredient))
        {
            Init();

        }


        public RelayCommand OpenFrontPage
        {
            get
            {
                return openFrontPage ?? (openFrontPage = new RelayCommand(param => this.OpenFrontPageExecute()));
            }
        }

        protected void OpenFrontPageExecute()
        {
            User u = null;



            foreach (User user in ModelContext.Instance.Users)
            {

                if (user.UserID == UserName  && user.Password == Password)
                {
                    u= user;

                }
            }


            if (u!= null)
            {
                ModelContext.Instance.User = u;
                FrontPageView front = new FrontPageView();
                MainWindow main = new MainWindow();
                main.Close();
                front.Owner = Application.Current.MainWindow;
                front.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                front.ShowDialog();


            }
          
            else
            {
                MessageBox.Show("Incorrect password or username!");
            }

          
        }


        protected override void Init()
        {
        }
        



    }
}
