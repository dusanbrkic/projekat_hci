using PROJEKAT_HCI.Database;
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
    /// Interaction logic for AzuriranjeSaradnikaWindow.xaml
    /// </summary>
    public partial class AzuriranjeSaradnikaWindow : Window
    {
        Saradnik s;
        public AzuriranjeSaradnikaWindow(Saradnik _s)
        {
            InitializeComponent();
            s = _s;
            Naziv.Text = s.Naziv;
            Opis.Text = s.Opis;
            Lokacija.Text = s.Lokacija;
            Tip.SelectedIndex = s.TipSaradnika == TipSaradnika.RESTORAN ? 0 : 1;
        }

        private void Azuriraj_saradnika_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ProjectDatabase())
            {
                var k2 = db.Saradnici.First(a => a.Id == s.Id);
                k2.Lokacija = Lokacija.Text;
                k2.Naziv = Naziv.Text;
                k2.Opis = Opis.Text;
                k2.TipSaradnika = Tip.SelectedIndex == 0 ? TipSaradnika.RESTORAN : TipSaradnika.POSLASTICARNICA;
                db.SaveChanges();

            }
            MessageBox.Show("Klijent je uspjesno azuriran.");
            this.Close();
        }

        private void odustao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
