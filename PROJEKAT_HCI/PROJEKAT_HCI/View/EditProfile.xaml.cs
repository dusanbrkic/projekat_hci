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
using PROJEKAT_HCI.Database;
using PROJEKAT_HCI.Model;
using ToastNotifications.Messages;
using WPFCustomMessageBox;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    

    public partial class EditProfile : Window
    {
        Korisnik Korisnik { get; set; }
        Window PreviousWindow { get; set; }
        public EditProfile(Window w, Korisnik k)
        {
            PreviousWindow = w;
            Korisnik = k;
            InitializeComponent();

            Username.Text = k.Username;
            Ime.Text = k.Ime;
            Prezime.Text = k.Prezime;
            BrojTelefona.Text = k.BrojTelefona;
            Password.Password = k.Password;
            PasswordPotvrda.Password = k.Password;
            Email.Text = k.Email;
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text == "" || Password.Password == "" || Ime.Text == "" || Prezime.Text == "" || BrojTelefona.Text == "")
            {
                MainWindow.notifier.ShowError("Imate prazna polja!");
                return;
            }


            if (PasswordPotvrda.Password != Password.Password)
            {
                MainWindow.notifier.ShowError("Lozinke se ne poklapaju!");
                return;
            }

            if (CustomMessageBox.ShowYesNo("Da li ste sigurni?", "Potvrda sigurnosti", "Da", "Ne") == MessageBoxResult.No)
                return;

            using (var db = new ProjectDatabase())
            {
                if (Korisnik is Organizator) {
                    Organizator organizator = db.Organizatori.Find(((Organizator)Korisnik).Id);
                    organizator.Ime = Ime.Text;
                    organizator.Prezime = Prezime.Text;
                    organizator.BrojTelefona = BrojTelefona.Text;
                    organizator.Email = Email.Text;
                    organizator.Password = Password.Password;


                } else if (Korisnik is Admin)
                {
                    Admin admin = db.Admini.Find(((Admin)Korisnik).Id);
                    admin.Ime = Ime.Text;
                    admin.Prezime = Prezime.Text;
                    admin.BrojTelefona = BrojTelefona.Text;
                    admin.Email = Email.Text;
                    admin.Password = Password.Password;
                }
                else if (Korisnik is Klijent)
                {
                    Klijent klijent = db.Klijenti.Find(((Klijent)Korisnik).Id);
                    klijent.Ime = Ime.Text;
                    klijent.Prezime = Prezime.Text;
                    klijent.BrojTelefona = BrojTelefona.Text;
                    klijent.Email = Email.Text;
                    klijent.Password = Password.Password;
                }

                db.SaveChanges();
            }

            Korisnik.Ime = Ime.Text;
            Korisnik.Prezime = Prezime.Text;
            Korisnik.BrojTelefona = BrojTelefona.Text;
            Korisnik.Email = Email.Text;
            Korisnik.Password = Password.Password;

            MainWindow.notifier.ShowSuccess("Uspesno ste promenili svoje podatke!");

            PreviousWindow.Show();
            this.Close();
        }

        private void Nazad_Button_Click(object sender, RoutedEventArgs e)
        {
            PreviousWindow.Show();
            this.Close();
        }

        
    }
}
