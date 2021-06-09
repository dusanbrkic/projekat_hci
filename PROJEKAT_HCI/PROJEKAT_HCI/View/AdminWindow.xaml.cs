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
using System.Drawing;
using System.Collections.ObjectModel;
using PROJEKAT_HCI.Model;

using BespokeFusion;
using PROJEKAT_HCI.Database;

namespace PROJEKAT_HCI.View
{
    public partial class AdminWindow : Window
    {
        public ObservableCollection<Saradnik> Saradnici
        {
            get;
            set;
        }
        public ObservableCollection<Klijent> Klijenti
        {
            get;
            set;
        }

        public MainWindow mw { get; set; }
        public ObservableCollection<Organizator> Organizatori
        {
            get;
            set;
        }

        public ObservableCollection<Ponuda> Ponude
        {
            get;
            set;
        }

        public AdminWindow()
        {
            
            InitializeComponent();
            this.DataContext = this;
            
           
            using (var db = new ProjectDatabase())
            {

                Klijenti = new ObservableCollection<Klijent>((from k in db.Klijenti select k).ToList());
                Organizatori = new ObservableCollection<Organizator>((from k in db.Organizatori select k).ToList());
                Saradnici = new ObservableCollection<Saradnik>((from k in db.Saradnici select k).ToList());
                Ponude = new ObservableCollection<Ponuda>((from k in db.Ponude select k).ToList());

            }




            
            
        }
        

       

       

        private void OdjavaBtn_Click(object sender, RoutedEventArgs e)
        {
            
            
            mw.Show();
            this.Close();

        }

        private void DodavanjeSaradnikaBtn_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeSaradnikaWindow ds = new DodavanjeSaradnikaWindow();
            ds.ShowDialog();
            Saradnik tmp = ds.Ret;
            if (tmp == null)
                return;

            Saradnici.Add(tmp);
        }

        

        private void DodavanjeKlijentaBtn_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeKlijentaWindow dw = new DodavanjeKlijentaWindow();
            dw.ShowDialog();
            Klijent tmp = dw.Ret;
            if (tmp == null)
                return;
            

            /*using (var db = new ManagerFactory())
            {
                db.klijenti.Add(tmp);
                db.SaveChanges();
            }*/

            Klijenti.Add(tmp);

            
        }

        private void KlijentiTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
                e.Cancel = true;

            if (e.PropertyName == "Password")
                e.Cancel = true;

            if (e.PropertyName == "BrojTelefona")
                e.Column.Header = "Broj telefona";

            if (e.PropertyName == "Username")
                e.Column.Header = "Korisničko ime";


        }

        private void AzurirajKlijentaBtn_Click(object sender, RoutedEventArgs e)
        {
            Klijent k = (Klijent) KlijentiTable.SelectedItem;
            if (k == null)
            {
                MaterialMessageBox.Show("Odaberite klijenta iz tabele", "Obavještenje", true);

                
                return;
            }
                

            AzuriranjeKlijentaWindow az = new AzuriranjeKlijentaWindow(k);
            az.ShowDialog();

            var k2 = Klijenti.FirstOrDefault(i => i.Id == k.Id);
            using (var db = new ProjectDatabase())
            {
                var item = db.Klijenti.First(i => i.Id == k.Id);
                k2.Ime = item.Ime;
                k2.Prezime = item.Prezime;
                k2.BrojTelefona = item.BrojTelefona;
                k2.Email = item.Email;
                k2.Username = item.Username;
                
            }

        }

        private void OrganizatoriTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
                e.Cancel = true;

            if (e.PropertyName == "Password")
                e.Cancel = true;

            if (e.PropertyName == "BrojTelefona")
                e.Column.Header = "Broj telefona";

            if (e.PropertyName == "Username")
                e.Column.Header = "Korisničko ime";

        }

        private void DodavanjeOrganizatoraBtn_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeOrganizatoraWindow dw = new DodavanjeOrganizatoraWindow();
            dw.ShowDialog();
            Organizator tmp = dw.Ret;
            if (tmp == null)
                return;


           

            Organizatori.Add(tmp);
        }

        private void AzurirajOrganizatoraBtn_Click(object sender, RoutedEventArgs e)
        {
            Organizator k = (Organizator) OrganizatoriTable.SelectedItem;
            if (k == null)
            {
                MaterialMessageBox.Show("Odaberite organizatora iz tabele", "Obavještenje", true);
                return;
            }


            AzuriranjeOrganizatoraWindow az = new AzuriranjeOrganizatoraWindow(k);
            az.ShowDialog();

            var k2 = Organizatori.FirstOrDefault(i => i.Id == k.Id);
            using (var db = new ProjectDatabase())
            {
                var item = db.Organizatori.First(i => i.Id == k.Id);
                k2.Ime = item.Ime;
                k2.Prezime = item.Prezime;
                k2.BrojTelefona = item.BrojTelefona;
                k2.Email = item.Email;
                k2.Username = item.Username;

            }
        }

        

        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
        }

        private void SaradniciTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
                e.Cancel = true;

            if (e.PropertyName == "Slike")
                e.Cancel = true;

            if (e.PropertyName == "Ponude")
                e.Cancel = true;

        }

        private void AzuriranjeSaradnikaBtn_Click(object sender, RoutedEventArgs e)
        {
            Saradnik k = (Saradnik) SaradniciTable.SelectedItem;
            if (k == null)
            {
                MaterialMessageBox.Show("Odaberite saradnika iz tabele", "Obavještenje", true);
                return;
            }

            AzuriranjeSaradnikaWindow asw = new AzuriranjeSaradnikaWindow(k);
            asw.ShowDialog();


            var k2 = Saradnici.FirstOrDefault(i => i.Id == k.Id);
            using (var db = new ProjectDatabase())
            {
                var item = db.Saradnici.First(i => i.Id == k.Id);
                k2.Opis = item.Opis;
                k2.Lokacija = item.Lokacija;
                k2.TipSaradnika = item.TipSaradnika;
                k2.Naziv = item.Naziv;
                
                 

            }
        }

        private void DodavanjePonudaBtn_Click(object sender, RoutedEventArgs e)
        {
            DodavanjePonudeAdminWindow dp = new DodavanjePonudeAdminWindow();
            dp.ShowDialog();

            Ponuda tmp = dp.Ret;
            if (tmp == null)
                return;

            Ponude.Add(tmp);

        }

        private void AzuriranjePonuda_Click(object sender, RoutedEventArgs e)
        {
            Ponuda p = (Ponuda) PonudeTable.SelectedItem;

            if (p == null)
                return;


            AzuriranjePonudeWindow az = new AzuriranjePonudeWindow(p);
            az.ShowDialog();

            var k2 = Ponude.FirstOrDefault(i => i.Id == p.Id);
            using (var db = new ProjectDatabase())
            {
                var item = db.Ponude.First(i => i.Id == p.Id);
                k2.Opis = item.Opis;
                k2.Slika = item.Slika;
                k2.Saradnik = item.Saradnik;
                k2.Cena = item.Cena;



            }
        }

        private void PonudeTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
                e.Cancel = true;

            if (e.PropertyName == "Slika")
                e.Cancel = true;

            if (e.PropertyName == "Klijent")
                e.Cancel = true;
            if(e.PropertyName == "Saradnik")
            {
                

            }

        }
    }
}
