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
    /// Interaction logic for PregledProslavaWindow.xaml
    /// </summary>
    public partial class PregledProslavaWindow : Window
    {
        public PregledProslavaWindow()
        {
            InitializeComponent();
        }

        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow();
            kw.Show();
            this.Close();
        }

    }
}
