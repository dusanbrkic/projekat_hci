using Microsoft.Win32;
using PROJEKAT_HCI.Database;
using PROJEKAT_HCI.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AzuriranjePonudeWindow.xaml
    /// </summary>
    public partial class AzuriranjePonudeWindow : Window
    {
        Ponuda p;
        public string imgSrc { get; set; }
        public AzuriranjePonudeWindow(Ponuda p_)
        {
            InitializeComponent();
            p = p_;
            using (var db = new ProjectDatabase())
            {
                foreach (Saradnik s in db.Saradnici)
                {
                    Saradnik.Items.Add(s.Naziv);
                }

            }
            Opis.Text = p.Opis;
            Cijena.Text = p.Cena.ToString();
            imgSrc = p.Slika;
            try
            {
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(p.Slika, UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                slika.Source = src;
            }
            catch (Exception e){ 
            }
            Saradnik.SelectedIndex = Saradnik.Items.IndexOf(p.Saradnik.Naziv);
        }

        private void Azuriraj_ponudu_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ProjectDatabase())
            {

                Saradnik sk = db.Saradnici.FirstOrDefault(saradnik => saradnik.Naziv == Saradnik.Text);
                if (sk == null)
                    return;
                /*Ponuda p = new Ponuda()
                {
                    Cena = int.Parse(Cijena.Text),
                    Opis = Opis.Text,
                    Slika = imgSrc,
                    Saradnik = sk
                };*/
                var k2 = db.Ponude.First(a => a.Id == p.Id);
                k2.Cena = int.Parse(Cijena.Text);
                k2.Opis = Opis.Text;
                k2.Slika = imgSrc;
                k2.Saradnik = sk;
                
                db.SaveChanges();
            }

            MainWindow.notifier.ShowInformation("Ponuda je uspješno ažurirana.");
            this.Close();

        }

        private void odustao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dodaj_slikuBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Image Files(*.JPG;)|*.JPG;|All files (*.*)|*.*";
            Nullable<bool> okdia = ofd.ShowDialog();
            if (okdia == true)
            {
                Random r = new Random();
                String newPath = "../../Res/Images/" + r.Next(10000, 1000000) + ".jpg";

                File.Copy(ofd.FileName, newPath);

                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(newPath, UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                slika.Source = src;
                imgSrc = newPath;
            }
        }
    }
}
