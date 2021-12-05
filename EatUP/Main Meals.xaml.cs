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
    /// Interaction logic for Main_Meals.xaml
    /// </summary>
    public partial class Main_Meals : UserControl
    {
        public Main_Meals()
        {
            InitializeComponent();
            loadContent();
        }

        private void loadContent()
        {
            using(EatUPContext foodtitemcontext = new EatUPContext())
            {
                MainMealsList.ItemsSource = foodtitemcontext.fooditemList.Where(a => a.Item_Category == "Main Meals" && a.Item_Status == 1).ToList();
            }
        }

        private void MainMealsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            {
                Food_Item tempitem = MainMealsList.SelectedItem as Food_Item;
                loginstatus.itemID = tempitem.Food_ItemID;
            }
            catch { }
            Qty newqty = new Qty();
            newqty.ShowDialog();


        }
    }




}
