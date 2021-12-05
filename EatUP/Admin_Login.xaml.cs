using EatUP.Database;
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
using System.Windows.Shapes;

namespace EatUP
{
    /// <summary>
    /// Interaction logic for Admin_Login.xaml
    /// </summary>
    public partial class Admin_Login : Window
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void btnAdmin_Login_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();


        }

        private void btn_AdminLogin_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                string _un = text_AdminLogin_username.Text;
                string _pw = text_AdminLogin_password.Password.ToString();

                using(EatUPContext admincontext = new EatUPContext())
                {
                    var q_res = admincontext.AdminList.Where(b => b.Admin_username == _un && b.Admin_password == _pw).ToList();
                    if (q_res.Count > 0)
                    {
                        //MessageBox.Show("success");
                        Admin_Pannel adminpannel = new Admin_Pannel();
                        adminpannel.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Something went worng. Please try again", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                

            }

            catch
            {
                MessageBox.Show("Something went worng. Please try again", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
