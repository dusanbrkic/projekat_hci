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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        Window MainWindow { get; set; }
        public RegistrationWindow(Window mw)
        {
            MainWindow = mw;
            InitializeComponent();
        }

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text == "" || Password.Password == "" || Ime.Text == "" || Prezime.Text == "" || BrojTelefona.Text == "")
            {
                Console.WriteLine("Greska");
                return;
            }


            if (PasswordPotvrda.Password != Password.Password)
                return;

            using (var db = new ProjectDatabase())
            {

                foreach (Klijent klijent in db.Klijenti)
                {
                    if (Username.Text == klijent.Username)//vec postoji korisnik sa istim usernamemom
                        return;

                }

                Klijent k = new Klijent { Id = db.Klijenti.Count(), Ime = Ime.Text, Prezime = Prezime.Text, BrojTelefona = BrojTelefona.Text, Email = Email.Text, Password = Password.Password, Username = Username.Text };


                db.Klijenti.Add(k);
                db.SaveChanges();
            }
        }

        private void Nazad_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Show();
            this.Close();
        }
    }
}
