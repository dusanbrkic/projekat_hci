using PROJEKAT_HCI.MENAGER;
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
    /// Interaction logic for DodavanjeKlijentaWindow.xaml
    /// </summary>
    public partial class DodavanjeKlijentaWindow : Window
    {
        public DodavanjeKlijentaWindow()
        {
            InitializeComponent();
        }

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Text == "" || ime.Text == "" || prezime.Text == "" || brojTelefona.Text == "")
            {
                Console.WriteLine("Greska");
                return;
            }


            if (againPassword.Text != password.Text)
                return;

            using (var db = new MangerFactory())
            {

                foreach (Klijent klijent in db.klijenti)
                {
                    if (username.Text == klijent.Username)//vec postoji korisnik sa istim usernamemom
                        return;

                }

                Klijent k = new Klijent { Id = db.klijenti.Count(), Ime = ime.Text, Prezime = prezime.Text, BrojTelefona = brojTelefona.Text, Email = email.Text, Password = password.Text, Username = username.Text };


                db.klijenti.Add(k);
                db.SaveChanges();
            }

        }

        private void odustao_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
