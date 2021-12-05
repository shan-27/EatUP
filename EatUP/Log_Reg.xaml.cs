using EatUP.Database;
using EatUP.Models;
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

namespace EatUP
{
    /// <summary>
    /// Interaction logic for Log_Reg.xaml
    /// </summary>
    public partial class Log_Reg : UserControl
    {
        public object GridPrincipal { get; private set; }

        public Log_Reg()
        {
            InitializeComponent();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {

            Reg R = new Reg();
            R.Show();
            


        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string _un = text_Login_username.Text;
            string _pw = text_Login_password.Password.ToString();
            try
            {   
                using(EatUPContext context = new EatUPContext())
                {
                    
                    var q_res = context.customerList.Where(b => b.username == _un && b.password == _pw).ToList();
                    if (q_res.Count > 0)
                    {
                        MessageBox.Show("Successfully logged in", "Login", MessageBoxButton.OK, MessageBoxImage.Information);

                        var x = q_res.Find(b => b.username == _un && b.password == _pw);
                        loginstatus.C_ID = x.CustomerID;
                        loginstatus.C_Address = x.Address;

                        loginstatus.s = 1;
                        //MessageBox.Show(loginstatus.s.ToString());

                        this.Visibility = Visibility.Hidden;

                        Uri uri = new Uri("Profile.xaml", UriKind.Relative);
                        NavigationService ns = NavigationService.GetNavigationService(this);
                        ns.Navigate(uri);



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
