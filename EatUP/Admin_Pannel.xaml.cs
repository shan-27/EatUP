using EatUP.Database;
using EatUP.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Admin_Pannel.xaml
    /// </summary>
    public partial class Admin_Pannel : Window
    {
        
        public Admin_Pannel()
        {
            InitializeComponent();
            retriveFoodList();
            btn_UpdateItem.IsEnabled = false;
            right.IsEnabled = false;
            list.IsEnabled = false;
            BrushConverter bc = new BrushConverter();
            Image_Grid.Background = (Brush)bc.ConvertFrom("#9D9D9D");

        }

        private void btnAdmin_Pannel_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }

        private void btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            right.IsEnabled = true;

            BrushConverter bc = new BrushConverter();
            Image_Grid.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

            try 
            {
                int statusval;
                float num;
                if ((bool)checkbox.IsChecked)
                    statusval = 1;
                else
                    statusval = 0;

                EatUPContext itemcontext = new EatUPContext();

                if (String.IsNullOrEmpty(text_ItemName.Text))
                    MessageBox.Show("Please add Item Name");
                else if (!float.TryParse(text_ItemPrice.Text, out num))
                    MessageBox.Show("Please enter valid price");
                else if (Category.SelectedItem == null)
                    MessageBox.Show("Please select a category");
                else if (String.IsNullOrEmpty(text_ItemDescription.Text))
                    MessageBox.Show("Please enter valid description");
                
                else 
                {
                   if (Item_Image.Source == null) 
                    {
                        var Result = MessageBox.Show("Are you sure you dont want item image ?", "There is no Image", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (Result == MessageBoxResult.Yes)
                        {
                            Food_Item item1 = new Food_Item()
                            {
                                Item_Name = text_ItemName.Text,
                                Item_Price = float.Parse(text_ItemPrice.Text),
                                Item_Category = Category.Text,
                                Item_Discription = text_ItemDescription.Text,
                                Item_Status = statusval,
                                Item_Imagecode = null,
                                Iten_ImageURL = null
                                

                            };

                            itemcontext.fooditemList.Add(item1);
                            itemcontext.SaveChanges();
                            MessageBox.Show("Item added successfully", "Items", MessageBoxButton.OK, MessageBoxImage.Information);
                            clear();
                            retriveFoodList();

                        }
                        else { };
                    }
                    else 
                    {
                        Food_Item item1 = new Food_Item()
                        {
                            Item_Name = text_ItemName.Text,
                            Item_Price = float.Parse(text_ItemPrice.Text),
                            Item_Category = Category.Text,
                            Item_Discription = text_ItemDescription.Text,
                            Item_Status = statusval,
                            Item_Imagecode = File.ReadAllBytes(text_itemURL.Text),
                            Iten_ImageURL = text_itemURL.Text

                        };


                        itemcontext.fooditemList.Add(item1);
                        itemcontext.SaveChanges();
                        MessageBox.Show("Item added successfully", "Items", MessageBoxButton.OK, MessageBoxImage.Information);
                        clear();
                        retriveFoodList();

                    };   

                }

            }
            catch 
            {
               MessageBox.Show("Please Try Again");
            }
            
        }





        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            clear();
            btn_AddItem.IsEnabled = true;
        }

        public void clear()
        {
            text_ItemName.Clear();
            text_ItemPrice.Clear();
            text_ItemDescription.Clear();
            Item_Image.Source = null;
            Category.SelectedItem = null;
            checkbox.IsChecked = false;
            text_itemURL.Clear();

            btn_UpdateItem.IsEnabled = false;
            list.IsEnabled = false;

            right.IsEnabled = false;
            BrushConverter bc = new BrushConverter();
            Image_Grid.Background = (Brush)bc.ConvertFrom("#9D9D9D");
        }


        public void retriveFoodList() 
        {
            try 
            {
                EatUPContext itemcontext = new EatUPContext();
                var fooditemlist = itemcontext.fooditemList.ToList();
                FOODLIST.ItemsSource = fooditemlist;
            }
            catch 
            {
                MessageBox.Show("List is empty", "List", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void btn_ImageBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Item_Image.Source = new BitmapImage(new Uri(op.FileName));
                text_itemURL.Text = op.FileName;
            }
        }

        private void btn_UpdateItem_Click(object sender, RoutedEventArgs e)
        {
            


            try
            {
                EatUPContext itemcontext = new EatUPContext();
                Food_Item item = FOODLIST.SelectedItem as Food_Item;
                if(item == null) 
                {
                    MessageBox.Show("Please select item to update", "Items", MessageBoxButton.OK, MessageBoxImage.Information);
                    btn_AddItem.IsEnabled = true;
                }
                else
                {
                    int ID = item.Food_ItemID;
                    var x = itemcontext.fooditemList.Find(ID);


                    int statusval;
                    float num;
                    if ((bool)checkbox.IsChecked)
                        statusval = 1;
                    else
                        statusval = 0;

                    if (String.IsNullOrEmpty(text_ItemName.Text))
                        MessageBox.Show("Please add Item Name", "Items", MessageBoxButton.OK, MessageBoxImage.Information);
                    else if (!float.TryParse(text_ItemPrice.Text, out num))
                        MessageBox.Show("Please enter valid price", "Items", MessageBoxButton.OK, MessageBoxImage.Information);
                    else if (Category.SelectedItem == null)
                        MessageBox.Show("Please select a category", "Items", MessageBoxButton.OK, MessageBoxImage.Information);
                    else if (String.IsNullOrEmpty(text_ItemDescription.Text))
                        MessageBox.Show("Please enter valid description", "Items", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                    {
                        if (Item_Image.Source == null)
                        {
                            var Result = MessageBox.Show("Are you sure you dont want item image ?", "There is no Image", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (Result == MessageBoxResult.Yes)
                            {
                                x.Item_Name = text_ItemName.Text;
                                x.Item_Price = float.Parse(text_ItemPrice.Text);
                                x.Item_Category = Category.Text;
                                x.Item_Discription = text_ItemDescription.Text;
                                x.Item_Status = statusval;
                                x.Item_Imagecode = null;
                                x.Iten_ImageURL = null;

                                itemcontext.SaveChanges();
                                MessageBox.Show("Item Updated Successfully", "Items", MessageBoxButton.OK, MessageBoxImage.Information);

                                
                                clear();


                            }
                            else 
                            {

                               MessageBox.Show("Please add a image and update again", "Items", MessageBoxButton.OK, MessageBoxImage.Information);
                                

                            };
                        }
                        else
                        {
                            x.Item_Name = text_ItemName.Text;
                            x.Item_Price = float.Parse(text_ItemPrice.Text);
                            x.Item_Category = Category.Text;
                            x.Item_Discription = text_ItemDescription.Text;
                            x.Item_Status = statusval;
                            x.Item_Imagecode = File.ReadAllBytes(text_itemURL.Text);
                            x.Iten_ImageURL = text_itemURL.Text;

                            itemcontext.SaveChanges();
                            clear();
                            MessageBox.Show("Item Updated Successfully", "Items", MessageBoxButton.OK, MessageBoxImage.Information);
                            

                            


                        };




                    }
                    list.IsEnabled = false;
                    btn_UpdateItem.IsEnabled = false;
                    btn_AddItem.IsEnabled = true;



                    retriveFoodList();


                }


            }
            catch
            {
                MessageBox.Show("Please Try Again", "Items", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            right.IsEnabled = false;
            BrushConverter bc = new BrushConverter();
            Image_Grid.Background = (Brush)bc.ConvertFrom("#9D9D9D");



        }

        private void btn_SelectItem_Click(object sender, RoutedEventArgs e)
        {
            list.IsEnabled = true;
            btn_AddItem.IsEnabled = false;




        }


        private void FOODLIST_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
         {

            right.IsEnabled = true;

            BrushConverter bc = new BrushConverter();
            Image_Grid.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

            btn_UpdateItem.IsEnabled = true;


            try
            {
                Food_Item item = FOODLIST.SelectedItem as Food_Item;
                if (item == null)
                {
                    text_ItemName.Text = " ";
                    text_ItemPrice.Text = " ";
                    Category.Text = null;
                    text_ItemDescription.Text = " ";
                    checkbox.IsChecked = false;
                }
                else
                { if(item.Item_Status == 1) 
                    {
                        if (item.Iten_ImageURL == null)
                        {
                            text_ItemName.Text = item.Item_Name;
                            text_ItemPrice.Text = Convert.ToString(item.Item_Price);
                            Category.Text = item.Item_Category;
                            text_ItemDescription.Text = item.Item_Discription;
                            checkbox.IsChecked = true;
                            text_itemURL.Text = null;
                            Item_Image.Source = null;
                            

                        }
                        else
                        {
                            text_ItemName.Text = item.Item_Name;
                            text_ItemPrice.Text = Convert.ToString(item.Item_Price);
                            Category.Text = item.Item_Category;
                            text_ItemDescription.Text = item.Item_Discription;
                            checkbox.IsChecked = true;
                            text_itemURL.Text = item.Iten_ImageURL;
                            Item_Image.Source = new BitmapImage(new Uri(item.Iten_ImageURL));
                        }
                    }
                    else
                    {
                        if (item.Iten_ImageURL == null)
                        {
                            text_ItemName.Text = item.Item_Name;
                            text_ItemPrice.Text = Convert.ToString(item.Item_Price);
                            Category.Text = item.Item_Category;
                            text_ItemDescription.Text = item.Item_Discription;
                            checkbox.IsChecked = false;
                            text_itemURL.Text = null;
                            Item_Image.Source = null;


                        }
                        else
                        {
                            text_ItemName.Text = item.Item_Name;
                            text_ItemPrice.Text = Convert.ToString(item.Item_Price);
                            Category.Text = item.Item_Category;
                            text_ItemDescription.Text = item.Item_Discription;
                            checkbox.IsChecked = false;
                            text_itemURL.Text = item.Iten_ImageURL;
                            Item_Image.Source = new BitmapImage(new Uri(item.Iten_ImageURL));
                        }
                    }
                    
                    

                    

                    
                }



            }
            catch
            {
                MessageBox.Show("Error");
            }


        }


    }
}
