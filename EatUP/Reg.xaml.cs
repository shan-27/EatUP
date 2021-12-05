using EatUP.Database;
using EatUP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(textFN.Text))
                MessageBox.Show("Please enter your first name", "Missing Field", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (String.IsNullOrEmpty(textLN.Text))
                MessageBox.Show("Please enter your last name", "Missing Field", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (!IsValid_Email(textEmail.Text))
                MessageBox.Show("Please enter valid email", "Email", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (String.IsNullOrEmpty(textAddress.Text))
                MessageBox.Show("Please enter the address", "Missing Field", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (String.IsNullOrEmpty(textCNO.Text))
                MessageBox.Show("Please enter your contact number", "Missing Field", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (Check_username(textUsername.Text))
                MessageBox.Show("This username is already taken", "Username", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (!IsValid_Password(textPassword.Password.ToString()))
                MessageBox.Show("Please enter a valid password", "Password", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                try
                {
                     using (EatUPContext context = new EatUPContext())
                     {
                         Customer CS1 = new Customer()
                         {
                             FirstName = textFN.Text,
                             LastName = textLN.Text,
                             Email = textEmail.Text,
                             ContactNO = textCNO.Text,
                             Address = textAddress.Text,
                             username = textUsername.Text,
                             password = textPassword.Password.ToString()
                         };

                         context.customerList.Add(CS1);
                         context.SaveChanges();
                         MessageBox.Show("Your Data is saved successfully", "Register", MessageBoxButton.OK, MessageBoxImage.Information);
                         clear();
                         this.Close();
                     }

                    
                }
                catch
                {
                    MessageBox.Show("Something went wrong. Please try again.", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    clear();
                }

                

            }


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clear()
        {
            textFN.Clear();
            textLN.Clear();
            textEmail.Clear();
            textCNO.Clear();
            textAddress.Clear();
            textUsername.Clear();
            textPassword.Clear();
        }

        public bool IsValid_Email(string n)
        {
            Regex check = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            bool valid = false;
            valid = check.IsMatch(n);

            if (valid == true)
            {
                return valid;
            }
            else
            {

                return valid;
            }
        }

        public bool IsValid_Password(string n)
        {
            Regex check = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            bool valid = false;
            valid = check.IsMatch(n);

            if (valid == true)
            {
                return valid;
            }
            else
            {

                return valid;
            }
        }

        public bool Check_username(string n)
        {
            using(EatUPContext context = new EatUPContext())
            {
                var list = context.customerList.Where(b => b.username == n ).ToList();
                if(list.Count > 0)
                    return true;

                else
                    return false;

            }
        }
    }
}
