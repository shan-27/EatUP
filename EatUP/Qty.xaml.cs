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
using System.Windows.Shapes;

namespace EatUP
{
    /// <summary>
    /// Interaction logic for Qty.xaml
    /// </summary>
    public partial class Qty : Window
    {
        public Qty()
        {
            InitializeComponent();
            
        }

        private void btn_addtocart_Click(object sender, RoutedEventArgs e)
        {
            if(loginstatus.s == 1)
            {
                if (textbox_qty.Text != "")
                {
                    int num_;
                    if (int.TryParse(textbox_qty.Text, out num_))
                    {
                        EatUPContext CartItem = new EatUPContext();
                        Food_Item Tempnew = CartItem.fooditemList.Find(loginstatus.itemID);

                        int Quantity = Convert.ToInt32(textbox_qty.Text);

                        Cart_model Tempitem = new Cart_model()
                        {
                            CItemID = loginstatus.itemID,
                            CItem_Name = Tempnew.Item_Name,
                            CQuantity = Quantity,
                            CItem_Price = Tempnew.Item_Price * Quantity

                        };
                        loginstatus.Carray.Add(Tempitem);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Valid Quantity", "EatUP", MessageBoxButton.OK, MessageBoxImage.Error);
                    }



                }
                else
                {
                    MessageBox.Show("Please Select Valid Quantity", "EatUP", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please login to select items", "EatUP", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }


        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
