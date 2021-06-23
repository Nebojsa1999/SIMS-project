using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIMS_Projekat.Model;
using SIMS_Projekat.UI.Dialogs.View;
using SIMS_Projekat.UI.Dialogs.ViewModel;

namespace SIMS_Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            initData();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
               User u = null;



            foreach (User user in ModelContext.Instance.Users)
               {

                   if (user.UserID == Username.Text && user.Password == Password2.Password)
                   {
                       u = user;

                   }
               }


               if (u != null)
               {
                    saveData();
                    ModelContext.Instance.User = u;
                    this.Hide();
                    FrontPageView front = new FrontPageView();
                    front.Top = this.Top + 20;
                    front.Owner = Application.Current.MainWindow;
                    front.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    front.ShowDialog();



            }

            else if (Username.Text == "admin" && Password2.Password == "admin")
            {
                this.Hide();
                FrontPageView front = new FrontPageView();
                front.Top = this.Top + 20;
                front.Owner = Application.Current.MainWindow;
                front.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                front.ShowDialog();
            }

            else
               {
                    MessageBox.Show("Incorrect password or username!");
                    counter++;
                    if (counter == 3)
                        {
                            this.Close();
                        }
               }
            


        }


        private void initData()
        {

            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if (Properties.Settings.Default.Renme == "yes")
                {
                    Username.Text = Properties.Settings.Default.UserName;
                    Password2.Password = Properties.Settings.Default.Password;
                    CheckBox.IsChecked = true;
                }

            }
        }

        private void saveData()
        {
            if (CheckBox.IsChecked == true)
            {
                Properties.Settings.Default.UserName = Username.Text;
                Properties.Settings.Default.Password = Password2.Password;
                Properties.Settings.Default.Renme = "yes";
                Properties.Settings.Default.Save();
            }

            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Renme = "no";
                Properties.Settings.Default.Save();
            }

        }

        
    }
}
