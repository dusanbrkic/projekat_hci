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
using WPFCustomMessageBox;

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
            BrojGostiju.Text = proslava.BrojGostiju.ToString();
            DatumProslave.SelectedDate = proslava.DatumOdrzavanja;
            using (var db = new ProjectDatabase())
            {
                var pros = (Proslava)(from p in db.Proslave where p.Id == proslava.Id select p).FirstOrDefault();
                Organizator.Text = pros.Organizator.Username + "-" + pros.Organizator.Ime + " " + pros.Organizator.Prezime;
            }


        }

        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            PregledProslavaWindow kw = new PregledProslavaWindow(klijent);
            kw.Show();
            this.Close();
        }

        private void PotvrdiZahtevBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Da li sigurni da zelite da otkazate proslavu?", "Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            if (res == MessageBoxResult.Yes)
            {
                MainWindow.notifier.ShowSuccess("Uspešno ste otkazali proslavu!");
                using (var db = new ProjectDatabase())
                {
                    var pros = (Proslava)(from p in db.Proslave where p.Id == proslava.Id select p).FirstOrDefault();
                    pros.StatusProslave = StatusProslave.OTKAZANA;

                    //db.Proslave.Add(pros);
                    db.SaveChanges();
                }

            }
        }

        private void UrediProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            EditProfile ep = new EditProfile(this, klijent);
            ep.Show();
            this.Hide();
        }
    }
}
