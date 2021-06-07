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
    /// Interaction logic for PregledPonudaWindow.xaml
    /// </summary>
    public partial class PregledPonudaWindow : Window
    {
        public PregledPonudaWindow()
        {
            InitializeComponent();
        }

        private void PotvrdiZahtevBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Ponuda_Click(object sender, RoutedEventArgs e)
        {
            PregledPonude pp = new PregledPonude();
            pp.Show();
            this.Close();
        }
    }
}
