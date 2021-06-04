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
    /// Interaction logic for DodavanjeSaradnikaWindow.xaml
    /// </summary>
    public partial class DodavanjeSaradnikaWindow : Window
    {
        public DodavanjeSaradnikaWindow()
        {
            InitializeComponent();
        }

        private void odustao_Click(object sender, RoutedEventArgs e)
        {

        }

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            

            using (var db = new ManagerFactory())
            {

                foreach (Saradnik sar in db.saradnici)
                {
                    if (Naziv.Text == sar.Naziv)//vec postoji korisnik sa istim usernamemom
                        return;

                }

                //Klijent k = new Klijent { Id = db.klijenti.Count(), Ime = ime.Text, Prezime = prezime.Text, BrojTelefona = brojTelefona.Text, Email = email.Text, Password = password.Text, Username = username.Text };


               // db.klijenti.Add(k);
                //db.SaveChanges();
            }

        }
    }
}
