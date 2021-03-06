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
    /// Interaction logic for DodavanjeKlijentaWindow.xaml
    /// </summary>
    public partial class DodavanjeKlijentaWindow : Window
    {
        public DodavanjeKlijentaWindow()
        {
            InitializeComponent();

        }
        private Klijent _klijent = null;
        public Klijent Ret { get { return _klijent; } set { _klijent = value; } }
        

        private void odustao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dodajKlijenta_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "" || ime.Text == "" || prezime.Text == "" || brojTelefona.Text == "" || email.Text == "")
            {
                MainWindow.notifier.ShowWarning("Sva polja moraju biti popunjena !");
                return;
            }


            if (againPassword.Password != password.Password)
            {
                MainWindow.notifier.ShowWarning("Lozinke se moraju poklapati !");
                return;
            }

            using (var db = new ProjectDatabase())
            {

                foreach (Klijent klijent in db.Klijenti)
                {
                    if (username.Text == klijent.Username)
                    {
                        MainWindow.notifier.ShowWarning("Postoji korisnik sa unijetim korisničkim imenom!");
                        return;
                    }
                }

                foreach (Organizator klijent in db.Organizatori)
                {
                    if (username.Text == klijent.Username)
                    {
                        MainWindow.notifier.ShowWarning("Postoji korisnik sa unijetim korisničkim imenom!");
                        return;
                    }
                }

                Klijent k = new Klijent { Id = db.Klijenti.Count(), Ime = ime.Text, Prezime = prezime.Text, BrojTelefona = brojTelefona.Text, Email = email.Text, Password = password.Password, Username = username.Text };
                Ret = k;

                db.Klijenti.Add(k);
                db.SaveChanges();
            }

            MainWindow.notifier.ShowInformation("Klijent je uspješno dodat.");

            this.Close();

        }
    }
}
