using PROJEKAT_HCI.Model;
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
    /// Interaction logic for PregledProslave.xaml
    /// </summary>
    public partial class PregledProslave : Window
    {
        private Proslava proslava;
        private Klijent klijent;

        public PregledProslave()
        {
            InitializeComponent();
        }

        public PregledProslave(Proslava proslava, Klijent klijent)
        {
            this.proslava = proslava;
            this.klijent = klijent;
            InitializeComponent();
            NazivProslave.Text = proslava.Naziv;
            OpisProslave.Text = proslava.Opis;
            Budzet.Text = proslava.Budzet.ToString();
        }

        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow(klijent);
            kw.Show();
            this.Close();
        }
    }
}
