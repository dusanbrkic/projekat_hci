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

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for PregledZahtevaProslave.xaml
    /// </summary>
    public partial class PregledZahtevaProslave : Window
    {
        Window OrganizatorProslava { get; set; }
        Proslava Proslava { get; set; }
        public PregledZahtevaProslave(Window op, Proslava p)
        {
            Proslava = p;
            OrganizatorProslava = op;
            InitializeComponent();

            Naziv.Text = Proslava.Naziv;
            OpisProslave.Text = Proslava.Opis;
            Budzet.Text = Proslava.Budzet.ToString();
            Datum.Text = Proslava.DatumOdrzavanja.ToString();
            BrGostiju.Text = Proslava.BrojGostiju.ToString();
            using (var db = new ProjectDatabase())
            {
                Proslava = db.Proslave.Find(Proslava.Id);
                Slavljenik.Text = Proslava.Klijent.Ime + " " + Proslava.Klijent.Prezime + " tel: " + Proslava.Klijent.BrojTelefona;
            }
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            OrganizatorProslava.Show();
            this.Hide();
        }
    }
}
