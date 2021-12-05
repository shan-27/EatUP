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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EatUP
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
            databind();
        }

        private void databind() 
        {
            using (EatUPContext context = new EatUPContext()) 
            {
                int C_ID = loginstatus.C_ID;
                var user = context.customerList.Find(C_ID);
                F_Name_txt.DataContext = user;
                Email_txt.DataContext = user;
                Add_txt.DataContext = user;
                CNO_txt.DataContext = user;
                ID_txt.DataContext = user;
            }
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0]);
        }
    }
}
