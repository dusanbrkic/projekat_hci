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
using ToastNotifications.Messages;

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
            
            foreach (TipSaradnika ss in Enum.GetValues(typeof(TipSaradnika)))
            {

                Tip.Items.Add(ss.ToString());
                

            }

            Tip.SelectedIndex = Tip.Items.IndexOf(s.TipSaradnika.ToString());
        }

        private void Azuriraj_saradnika_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ProjectDatabase())
            {
                var k2 = db.Saradnici.First(a => a.Id == s.Id);
                k2.Lokacija = Lokacija.Text;
                k2.Naziv = Naziv.Text;
                k2.Opis = Opis.Text;
                Enum.TryParse(Tip.Text, out TipSaradnika t);
                k2.TipSaradnika = t;
                db.SaveChanges();

            }
            
            MainWindow.notifier.ShowInformation("Saradnik je uspješno ažuriran.");
            this.Close();
        }

        private void odustao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
