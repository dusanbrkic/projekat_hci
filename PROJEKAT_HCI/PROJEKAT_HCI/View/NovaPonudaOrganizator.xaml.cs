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
    /// <summary>
    /// Interaction logic for NovaPonudaOrganizator.xaml
    /// </summary>
    public partial class NovaPonudaOrganizator : Window
    {

        public OrganizatorSaradnikWindow os { get; set; }

        public String imgSrc { get; set; }

        public Saradnik Saradnik;
        public NovaPonudaOrganizator(OrganizatorSaradnikWindow osw, Saradnik s)
        {
            InitializeComponent();
            this.Saradnik = s;
            this.os = osw;
            this.imgSrc = "";
        }
        private void Nazad_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            os.Dodaj_Ponude();
            os.Show();
        }

        private void Nova_Ponuda_Btn(object sender, RoutedEventArgs e)
        {
            if (Opis.Text.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Ponuda mora sadrzati opis!");
                return;
            }
            int i;
            bool b = int.TryParse(Cena.Text, out i);
            if (!b)
            {
                MainWindow.notifier.ShowWarning("Morate uneti broj za kao cenu ponude!");
                return;
            }
            if (i < 0)
            {
                MainWindow.notifier.ShowWarning("Cena mora biti pozitivna!");
                return;
            }
            if (imgSrc.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Ponuda mora imati sliku!");
                return;
            }
            MessageBoxResult res = CustomMessageBox.ShowYesNo( "Jeste li sigurni da zelite da dodate novu ponudu?" ,"Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            if(res== MessageBoxResult.Yes)
            {
                using(var db = new ProjectDatabase())
                {
                    Saradnik sk = db.Saradnici.Find(Saradnik.Id);
                    Ponuda p = new Ponuda()
                    {
                        Cena = i,
                        Opis = Opis.Text,
                        Slika = imgSrc,
                        Saradnik = sk
                    };

                    db.Ponude.Add(p);
                    db.SaveChanges();
                }
            }
            MainWindow.notifier.ShowSuccess("Uspešno ste dodali ponudu, svaka čast!");
            this.Close();
            os.Dodaj_Ponude();
            os.Show();
        }

        private void Image_Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Image Files(*.JPG;)|*.JPG;|All files (*.*)|*.*";
            Nullable<bool> okdia = ofd.ShowDialog();
            if(okdia == true)
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
