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
    /// Interaction logic for Bev_and_Desserts.xaml
    /// </summary>
    public partial class Bev_and_Desserts : UserControl
    {
        public Bev_and_Desserts()
        {
            InitializeComponent();
            loadContent();
            
        }

        private void loadContent()
        {
            using(EatUPContext foodtitemcontext = new EatUPContext())
            {
                BevandDessertslist.ItemsSource = foodtitemcontext.fooditemList.Where(a => a.Item_Category == "Beverages & Deserts" && a.Item_Status == 1).ToList();
            }
        }

        private void BevandDessertslist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            {
                Food_Item tempitem = BevandDessertslist.SelectedItem as Food_Item;
                loginstatus.itemID = tempitem.Food_ItemID;
            }
            catch { }
            Qty newqty = new Qty();
            newqty.ShowDialog();
        }
    }
}
