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
using PROJEKAT_HCI.Model;
using PROJEKAT_HCI.Database;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ToastNotifications.Messages;
using MaterialDesignThemes.Wpf;
using DataObject = System.Windows.Forms.DataObject;
using DragDropEffects = System.Windows.DragDropEffects;
using DragEventArgs = System.Windows.DragEventArgs;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for OrganizatorProslava.xaml
    /// </summary>
    public partial class OrganizatorProslava : Window
    {
        public Proslava Proslava{get; set;}
        public Zadatak SelektovanZadatak { get; set; }
        public Zadatak NosenZadatak { get; set; }
        public Card NosenaKartica { get; set; }
        public OrganizacijaProslavaWindow opw { get; set; }
        public OrganizatorProslava(OrganizacijaProslavaWindow parent, Proslava p)
        {
            this.opw = parent;
            this.Proslava = p;
            
            InitializeComponent();
            Dodaj_Zadatke();

        }

        public void Dodaj_Zadatke()
        {
            Za_uraditi_stek.Children.Clear();
            U_obradi_stek.Children.Clear();
            Za_poslati_stek.Children.Clear();
            Poslato_stek.Children.Clear();
            Za_izmenu_stek.Children.Clear();
            Odbijeno_stek.Children.Clear();
            Prihvaceno_stek.Children.Clear();
            using(var db =  new ProjectDatabase())
            {
                Proslava p = db.Proslave.Find(Proslava.Id);
                List<Zadatak> zadaci = p.PredlogProslave.Zadaci;
                foreach(Zadatak z in zadaci)
                {
                    Card card = new Card();
                    card.MouseLeftButtonDown += OtpustenMis;
                    card.Content = z.Naziv;
                    card.Tag = z;
                    switch (z.Status)
                    {
                        case Status_Zadatka.ZA_URADITI:
                            Za_uraditi_stek.Children.Add(card);
                            break;
                        case Status_Zadatka.U_OBRADI:
                            U_obradi_stek.Children.Add(card);
                            break;
                        case Status_Zadatka.ZA_POSLATI:
                            Za_poslati_stek.Children.Add(card);
                            break;
                        case Status_Zadatka.POSLATO:
                            Poslato_stek.Children.Add(card);
                            break;
                        case Status_Zadatka.ZA_IZMENU:
                            Za_izmenu_stek.Children.Add(card);
                            break;
                        case Status_Zadatka.ODBIJENO:
                            Odbijeno_stek.Children.Add(card);
                            break;
                        case Status_Zadatka.PRIHVACENO:
                            Prihvaceno_stek.Children.Add(card);
                            break;
                    }
                }

            }
        }

        public void OtpustenMis(object sender, MouseButtonEventArgs args)
        {
            Card c = (Card)sender;
            DataObject data = new DataObject(c.Tag);
            //data.
            //Console.WriteLine(((Zadatak)c.Tag).Opis);
            NosenZadatak = (Zadatak)c.Tag;
            NosenaKartica = c;
            DragDrop.DoDragDrop(c, data, DragDropEffects.Move);

        }

        public void Target_Drop_U_Obradi(object sender, DragEventArgs args)
        {
            StackPanel sp = (StackPanel)NosenaKartica.Parent;
            sp.Children.Remove(NosenaKartica);
            U_obradi_stek.Children.Add(NosenaKartica);
            using(var db = new ProjectDatabase())
            {
                Zadatak z = db.Zadaci.Find(NosenZadatak.Id);
                z.Status = Status_Zadatka.U_OBRADI;
                db.SaveChanges();
            }
            NosenZadatak.Status = Status_Zadatka.U_OBRADI;
        }
        public void Target_Drop_Za_Uraditi(object sender, DragEventArgs args)
        {
            StackPanel sp = (StackPanel)NosenaKartica.Parent;
            sp.Children.Remove(NosenaKartica);
            Za_uraditi_stek.Children.Add(NosenaKartica);
            using (var db = new ProjectDatabase())
            {
                Zadatak z = db.Zadaci.Find(NosenZadatak.Id);
                z.Status = Status_Zadatka.ZA_URADITI;
                db.SaveChanges();
            }
            NosenZadatak.Status = Status_Zadatka.ZA_URADITI;
        }
        public void Target_Drop_Za_Poslati(object sender, DragEventArgs args)
        {
            StackPanel sp = (StackPanel)NosenaKartica.Parent;
            sp.Children.Remove(NosenaKartica);
            Za_poslati_stek.Children.Add(NosenaKartica);
            using (var db = new ProjectDatabase())
            {
                Zadatak z = db.Zadaci.Find(NosenZadatak.Id);
                z.Status = Status_Zadatka.ZA_POSLATI;
                db.SaveChanges();
            }
            NosenZadatak.Status = Status_Zadatka.ZA_POSLATI;
        }
        public void Target_Drop_Za_Izmenu(object sender, DragEventArgs args)
        {
            StackPanel sp = (StackPanel)NosenaKartica.Parent;
            sp.Children.Remove(NosenaKartica);
            Za_izmenu_stek.Children.Add(NosenaKartica);
            using (var db = new ProjectDatabase())
            {
                Zadatak z = db.Zadaci.Find(NosenZadatak.Id);
                z.Status = Status_Zadatka.ZA_IZMENU;
                db.SaveChanges();
            }
            NosenZadatak.Status = Status_Zadatka.ZA_IZMENU;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            opw.Show();
            this.Close();
        }
        private void Dodaj_Zadatak_Click(object sender, RoutedEventArgs e)
        {
            string odg = Interaction.InputBox("Unesite naziv zadatka", "Novi zadatak", "", 500, 300);

            if (odg.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Niste uneli naziv zadatka!");
                return;
            }
            using(var db = new ProjectDatabase())
            {
                Proslava p = db.Proslave.Find(Proslava.Id);
                Zadatak z = new Zadatak()
                {
                    PredlogProslave = p.PredlogProslave,
                    Naziv = odg,
                    Status = Status_Zadatka.ZA_URADITI,
                    Opis = "",
                };
                Console.WriteLine(z.Opis);
                db.Zadaci.Add(z);
                db.SaveChanges();
                Dodaj_Zadatke();
            }
        }

        private void U_obradi_stek_Drop(object sender, DragEventArgs e)
        {

        }

        private void Zahtev_Click(object sender, RoutedEventArgs e)
        {
            PregledZahtevaProslave pzp = new PregledZahtevaProslave(this, Proslava);
            pzp.Show();
            this.Hide();
        }
    }
}
