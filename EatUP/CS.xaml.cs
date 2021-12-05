using EatUP.Database;
using EatUP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EatUP
{
    /// <summary>
    /// Interaction logic for CS.xaml
    /// </summary>
    public partial class CS : UserControl
    {

        

        public CS()
        {
            InitializeComponent();
        }



        private void btn_CS_send_Click(object sender, RoutedEventArgs e)
        {
            if (loginstatus.s == 1) 
            {
                if (String.IsNullOrEmpty(text_CS_Name.Text))
                    MessageBox.Show("Please enter your name", "Missing Text", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (!IsValid_Email(text_CS_Email.Text))
                    MessageBox.Show("Please enter valid email", "Email", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (String.IsNullOrEmpty(text_CS_Subject.Text))
                    MessageBox.Show("Please enter the subject", "Missing Text", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (String.IsNullOrEmpty(text_CS_Message.Text))
                    MessageBox.Show("Please enter your message", "Missing Text", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    try
                    {
                       using(EatUPContext context = new EatUPContext())
                        {
                            CS_form newForm = new CS_form()
                            {
                                CS_form_Name = text_CS_Name.Text,
                                CS_form_Email = text_CS_Email.Text,
                                CS_form_Subject = text_CS_Subject.Text,
                                CS_form_Message = text_CS_Message.Text,
                                CS_ID = loginstatus.C_ID


                            };

                            context.CSform_list.Add(newForm);
                            context.SaveChanges();
                        }


                        //sendEmail();
                        //IsValid_Email(text_CS_Email.Text);

                        MessageBox.Show("Your response is submitted successfully", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        clear();


                    }
                    catch
                    {
                        MessageBox.Show("Somthing happend. Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    }


                }


            }
            else
            {
                MessageBox.Show("Please login in to your account", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            
        }


        private void sendEmail() 
        {
            MailMessage mail = new MailMessage();
            SmtpClient Smtp = new SmtpClient("smtp.google.com");

            mail.From = new MailAddress(text_CS_Email.Text);
            mail.To.Add("lakshanshami27@gmail.com");
            mail.Subject= text_CS_Subject.Text;
            mail.Body = text_CS_Message.Text;

            Smtp.Port = 587;
            Smtp.Credentials = new System.Net.NetworkCredential(text_CS_Email.Text, "Dhammika70");

            Smtp.Send(mail);
            MessageBox.Show("Email sent", "Email sent", MessageBoxButton.OK, MessageBoxImage.Information);

        }



        public bool IsValid_Email(string n) 
        {
            Regex check = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            bool valid = false;
            valid = check.IsMatch(n);

            if(valid == true)
            {
                return valid;
            }
            else 
            {
                
                return valid;
            }
        }


        public void clear() 
        {
            text_CS_Name.Clear();
            text_CS_Email.Clear();
            text_CS_Subject.Clear();
            text_CS_Message.Clear();
           
        }
        
    }
}
