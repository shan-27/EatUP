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
    //Public Variables

    public static class loginstatus 
    {
        public static int s = 0;
        public static List<Cart_model> Carray = new List<Cart_model>();
        public static int itemID = 0;
        public static int C_ID = 0;
        public static string C_Address = "";
        public static int OrderDetailsID = 0;
    }

    

    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //defaultcart();

        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Blank());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Store());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    if (loginstatus.s == 1)
                    {
                        if(loginstatus.Carray.Count ==0)
                        {
                            GridPrincipal.Children.Add(new Cart_Empty());
                        }
                        else
                        {
                            GridPrincipal.Children.Add(new Cart());
                        }
                        
                    }
                    else 
                    {
                        GridPrincipal.Children.Add(new Cart_Error());
                        MessageBox.Show("Please login to your account", "Alert");
                    }
                    
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new CS());
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new About());
                    break;
                case 5:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new About());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void facebook_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/");
        }

        private void twitter_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitter.com/");
        }

        private void insta_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        private void Admin_Click_1(object sender, RoutedEventArgs e)
        {
            Admin_Login admin = new Admin_Login();
            admin.Show();
            this.Close();

            try
            { EatUPContext admincontext = new EatUPContext();
                Admin A1 = new Admin()
                {
                 Admin_username = "admin",
                    Admin_password = "admin"
                };

                 admincontext.AdminList.Add(A1);
                admincontext.SaveChanges(); 
            }
            catch { }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0]);
        }

        /*private void defaultcart()
        {
            Cart_model Tempitem = new Cart_model()
            {
                CItemID = 0,
                CItem_Name = "Item",
                CQuantity = 0,
                CItem_Price = 0

            };
            loginstatus.Carray.Add(Tempitem);
        }*/
    }
}
