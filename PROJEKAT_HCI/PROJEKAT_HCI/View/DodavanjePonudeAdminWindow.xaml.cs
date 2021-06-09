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

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for DodavanjePonudeAdminWindow.xaml
    /// </summary>
    public partial class DodavanjePonudeAdminWindow : Window
    {
        public String imgSrc { get; set; }
      
        public Ponuda Ret { get; set; }
        public DodavanjePonudeAdminWindow()
        {
            InitializeComponent();

            using (var db = new ProjectDatabase())
            {
                foreach (Saradnik s in db.Saradnici) {
                    Saradnik.Items.Add(s.Naziv);
                }
                
            }
            
        }

        private void Dodaj_ponudu_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ProjectDatabase())
            {
                
                Saradnik sk =  db.Saradnici.FirstOrDefault(saradnik => saradnik.Naziv == Saradnik.Text);
                if (sk == null)
                    return;
                Ponuda p = new Ponuda()
                {
                    Cena = int.Parse(Cijena.Text),
                    Opis = Opis.Text,
                    Slika = imgSrc,
                    Saradnik = sk
                };
                Ret = p;
                db.Ponude.Add(p);
                db.SaveChanges();
            }
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
