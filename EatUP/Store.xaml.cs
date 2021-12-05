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
    /// Interaction logic for Store.xaml
    /// </summary>
    public partial class Store : UserControl
    {
        public Store()
        {
            InitializeComponent();
            item_list.Children.Clear();
            item_list.Children.Add(new Main_Meals());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            item_list.Children.Clear();
            item_list.Children.Add(new Main_Meals());

        }

        private void SandS_Click(object sender, RoutedEventArgs e)
        {
            item_list.Children.Clear();
            item_list.Children.Add(new Soups_and_Salads());
        }

        private void BevandDesserts_Click(object sender, RoutedEventArgs e)
        {
            
            item_list.Children.Clear();
            item_list.Children.Add(new Bev_and_Desserts());

        }
    }
}
