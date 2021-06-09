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
using Microsoft.Win32;
using System.IO;
using ToastNotifications.Messages;
using System.ComponentModel;
using WPFCustomMessageBox;

namespace PROJEKAT_HCI.View
{
    
    public partial class DodajSaradnikaOrganizator : Window
    {
        public OrganizatorSaradnici os { get; set; }
        public String img;
        public DodajSaradnikaOrganizator(OrganizatorSaradnici o)
        {
            this.os = o;
            this.img = "";
            InitializeComponent();
            foreach (TipSaradnika ss in Enum.GetValues(typeof(TipSaradnika)))
            {

                Tip.Items.Add(ss.ToString());
                
            }
            Tip.SelectedItem = "OSTALO";


        }

        private void Nazad_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            os.Dodaj_Saradnike();
            os.Show();
        }

        private void Image_Btn_Click(object sender, RoutedEventArgs e)
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
                this.img = newPath;

            }
        }

        private void Nov_Saradnik_Ponuda_Btn(object sender, RoutedEventArgs e)
        {
            if (Naziv.Text.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Saradnik mora imati naziv!");
                return;
            }
            if (Opis.Text.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Saradnik mora sadržati opis mora sadrzati opis!");
                return;
            }
            if (Lokacija.Text.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Saradnik mora imati lokaciju!");
                return;
            }
            if (img.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Saradnik mora imati sliku");
                return;
            }
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Jeste li sigurni da zelite da dodate novog saradnika?", "Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            if(res == MessageBoxResult.Yes)
            {
                using (var db = new ProjectDatabase())
                {
                    List<String> oslk = new List<string>();
                    Enum.TryParse(Tip.Text, out TipSaradnika t);
                    oslk.Add(this.img);
                    Saradnik s = new Saradnik()
                    {
                        Naziv = Naziv.Text,
                        Opis = Opis.Text,
                        Lokacija = Lokacija.Text,
                        Slike = oslk,
                        TipSaradnika = t,
                    };

                    db.Saradnici.Add(s);
                    db.SaveChanges();
                }
                MainWindow.notifier.ShowSuccess("Čestitamo, nov saradnik uspešno dodat");
                this.Close();
                os.Dodaj_Saradnike();
                os.Show();

            }
        }
    }
}
