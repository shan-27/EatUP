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
    /// Interaction logic for STUP_Win.xaml
    /// </summary>
    public partial class STUP_Win : Window
    {
        public STUP_Win()
        {
            InitializeComponent();
        }

        private void StUPNext_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
