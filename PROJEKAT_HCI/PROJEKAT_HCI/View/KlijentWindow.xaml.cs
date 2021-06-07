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

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for KlijentWindow.xaml
    /// </summary>
    public partial class KlijentWindow : Window
    {
        public KlijentWindow()
        {
            InitializeComponent();
        }

        private void OdjavaBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NovaProslavaBtn_Click(object sender, RoutedEventArgs e)
        {
            NovaProslavaWindow npw = new NovaProslavaWindow();
            npw.Show();
            this.Close();
        }
        private void PregledProslavaBtn_Click(object sender, RoutedEventArgs e)
        {
            PregledProslavaWindow ppw = new PregledProslavaWindow();
            ppw.Show();
            this.Close();
        }
        private void PregledPonudaBtn_Click(object sender, RoutedEventArgs e)
        {
            PregledPonudaWindow ppw = new PregledPonudaWindow();
            ppw.Show();
            this.Close();
        }
    }
}
