using PROJEKAT_HCI.Database;
using PROJEKAT_HCI.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NovaProslavaWindow.xaml
    /// </summary>
    public partial class NovaProslavaWindow : Window
    {
        private Klijent klijent { get; set; }

        private List<Organizator> organizatori { get; set; }
        public NovaProslavaWindow(Klijent klijent)
        {
            this.klijent = klijent;
            InitializeComponent();
            LoadOrganizatore();
        }
        private void LoadOrganizatore()
        {
            using (var db = new ProjectDatabase())
            {
                organizatori = new List<Organizator>();
                foreach (Organizator o in (from o in db.Organizatori select o).ToList())
                {
                    OrganizatorComboBox.Items.Add(o.Username + "-" + o.Ime + " " + o.Prezime);
                    organizatori.Add(o);
                }
            }
        }
        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow(klijent);
            kw.Show();
            this.Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void DoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);  
        }
        public class FutureDateValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                DateTime time;
                if (!DateTime.TryParse((value ?? "").ToString(),
                    CultureInfo.CurrentCulture,
                    DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                    out time)) return new ValidationResult(false, "Invalid date");

                return time.Date <= DateTime.Now.Date
                    ? new ValidationResult(false, "Future date required")
                    : ValidationResult.ValidResult;
            }

        }
        private Organizator PronadjiOrganizatora(String username)
        {
            foreach(Organizator o in organizatori)
            {
                if (o.Username.Equals(username))
                {
                    return o;
                }
            }
            return null;
        }
        private void PotvrdiZahtevBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NazivProslave.Text.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Niste uneli naziv proslave!");
                return;
            }
            if (OpisProslave.Text.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Niste uneli opis proslave!");
                return;
            }
            if (DatumProslave.SelectedDate == null)
            {
                MainWindow.notifier.ShowWarning("Niste uneli datum proslave!");
                return;
            }
            if (BrojGostiju.Text.Equals(""))
            {

                MainWindow.notifier.ShowWarning("Niste uneli broj gostiju!");
                return;
            }
            if (Int32.Parse(BrojGostiju.Text) == 0)
            {
                MainWindow.notifier.ShowWarning("Broj gostiju mora biti veci od 0!");
                return;
            }
            if (Budzet.Text.Equals(""))
            {

                MainWindow.notifier.ShowWarning("Niste uneli budzet!");
                return;
            }
            if (Int32.Parse(Budzet.Text) == 0)
            {
                MainWindow.notifier.ShowWarning("Budzet mora biti veci od 0!");
                return;
            }
            String organizatorText = (string)OrganizatorComboBox.Text;
            if (organizatorText.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Niste izabrali organizatora");
                return;
            }
            String organizatorUserName = organizatorText.Split('-')[0];
            Organizator org = PronadjiOrganizatora(organizatorUserName);
            if(org == null)
            {
                MainWindow.notifier.ShowWarning("Niste izabrali organizatora");
                return;
            }
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Da li ste sigurni da zelite da organizujete proslavu?", "Potvrda organizacije proslave", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            if (res == MessageBoxResult.Yes)
            {


                using (var db = new ProjectDatabase())
                {
                    Proslava p = new Proslava() { 
                        Klijent = (Klijent)(from k in db.Klijenti
                                            where k.Username == this.klijent.Username
                                            select k).FirstOrDefault(),
                        Organizator = (Organizator)(from o in db.Organizatori where o.Username == organizatorUserName select o).FirstOrDefault(),
                        BrojGostiju = Int32.Parse(BrojGostiju.Text),
                        Naziv = NazivProslave.Text,
                        Opis = OpisProslave.Text,
                    
                        Budzet = Int32.Parse(Budzet.Text),
                        DatumOdrzavanja = DateTime.Parse(DatumProslave.Text),
                        StatusProslave = StatusProslave.CEKA_SE_ORGANIZATOR };

                    //sacuvamo proslavu
                    p = db.Proslave.Add(p);

                    //pravimo predlogProslave
                    PredlogProslave predlogProslave = new PredlogProslave();
                    predlogProslave.Zadaci = new List<Zadatak>();
                    //predlogProslave.Id = p.Id;
                    predlogProslave.Proslava = p;
                    db.Predlozi.Add(predlogProslave);
                    db.SaveChanges();
                }
            MainWindow.notifier.ShowSuccess("Uspesno ste dodali novu proslavu!");
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
