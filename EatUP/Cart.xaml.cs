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
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : UserControl
    {
        public Cart()
        {
            InitializeComponent();
            Load();

        }

        public void Load()
        {
            float sum = 0;
            try 
            {
                for (int i = 0; i < 100; i++)
                {
                    Cartlist.Items.Add(loginstatus.Carray[i]);
                    sum += loginstatus.Carray[i].CItem_Price;
                    
                }
            }
            catch { }
            totaltext.Text = Convert.ToString(sum);

        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            loginstatus.Carray.Clear();
            Cartlist.Items.Clear();
            Load();
        }

        private void btn_ordernow_Click(object sender, RoutedEventArgs e)
        {
            if(loginstatus.Carray.Count==0)
            {
                MessageBox.Show("Cart is Empty", "EatUP", MessageBoxButton.OK, MessageBoxImage.Warning);
            
            }
            else 
            {   //Adding_Order

                using(EatUPContext context = new EatUPContext())
                {
                    DateTime dateTime = DateTime.UtcNow.Date;
                    Main_Order_Details Details = new Main_Order_Details()
                    {
                        Rand_Order_id = 1,
                        _Customer_iD = loginstatus.C_ID,
                        Order_Date = dateTime.ToString(),
                        Order_Time = DateTime.Now.ToString("h:mm:ss tt"),
                        TotalBill = totaltext.Text,
                    };
                    context.Main_Order_DetailsList.Add(Details);
                    context.SaveChanges();
                    EatUPContext context1 = new EatUPContext();
                    loginstatus.OrderDetailsID = Details.Main_Order_DetailsID;
                    try
                    {

                        for (int i = 0; i < 100; i++)
                        {
                            Cart_model tempc = loginstatus.Carray[0];
                            Order neworder = new Order()
                            {
                                _DetailsID = loginstatus.OrderDetailsID,
                                Item_id = tempc.CItemID,
                                Itemname = tempc.CItem_Name,
                                Quantity = tempc.CQuantity,
                            };
                            context1.OrderList.Add(neworder);
                            loginstatus.Carray.Remove(tempc);
                        }


                    }
                    catch
                    {
                    }
                    context1.SaveChanges();

                    MessageBox.Show("Your Order has been Placed Successfully", "EatUP", MessageBoxButton.OK, MessageBoxImage.Information);
                    Cartlist.Items.Clear();

                }




            }
        }
    }
}
