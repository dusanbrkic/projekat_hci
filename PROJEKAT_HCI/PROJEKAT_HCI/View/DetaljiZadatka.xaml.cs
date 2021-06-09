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
using PROJEKAT_HCI.Database;
using MaterialDesignThemes.Wpf;
using ToastNotifications.Messages;
using WPFCustomMessageBox;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for DetaljiZadatka.xaml
    /// </summary>
    public partial class DetaljiZadatka : Window
    {
        public OrganizatorProslava op { get; set; }
        public Zadatak Zadatak;
        public String Search;
        public bool Editable;
        public DetaljiZadatka(Zadatak z, OrganizatorProslava op)
        {

            InitializeComponent();
            Ponuda pt = null;
            Saradnik sk;
            //z.Ponuda = pt;

            using(var db = new ProjectDatabase())
            {
                Zadatak t = db.Zadaci.Find(z.Id);
                if (t.Ponuda != null)
                {
                    pt = db.Ponude.Find(t.Ponuda.Id);
                    sk = db.Saradnici.Find(pt.Saradnik.Id);
                    z.Ponuda = pt;
                    z.Ponuda.Saradnik = sk;
                    if (pt == null)
                    {
                    
                    }
                    else
                    {
                        Ponuda_Text.Text = pt.Opis + ", " + pt.Cena + " dinara, " + pt.Saradnik.Naziv;
                    }


                }
                else
                {
                    Ponuda_Text.Text = "Nije odabrana nijedna ponuda";

                }
                
            }
            
            this.Zadatak = z;
            this.op = op;
            this.Search = "";
            if(z.Status==Status_Zadatka.ODBIJENO || z.Status==Status_Zadatka.POSLATO || z.Status == Status_Zadatka.ODBIJENO)
            {
                this.Editable = false;
            }
            else
            {
                this.Editable = true;
            }
            //Ponuda p = z.Ponuda;
            
            Naziv_Zadatka.Text = z.Naziv;
            if (z.Opis == null)
            {
                Opis_Zadatka.Text = "";
            }
            else
            {
                Opis_Zadatka.Text = z.Opis;
            }
            if (z.KomentarKlijenta == null)
            {
                Komentar.Text = "";
            }
            else
            {
                Komentar.Text = z.KomentarKlijenta;
            }
            Menjac.IsEnabled = false;
            Dodaj_Ponude();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            op.Dodaj_Zadatke();
            op.Show();
        }
        
        public void Dodaj_Ponude()
        {
            wrapper.Children.Clear();
            using (var db = new ProjectDatabase())
            {
                foreach (var p in (from p in db.Ponude where p.Opis.ToLower().Contains(this.Search) select p))
                {

                    

                    Card card = new Card();
                    card.Width = 340;
                    card.Height = 380;
                    card.Margin = new Thickness(5, 5, 5, 5);

                    Image i = new Image();
                    i.Width = 200;
                    i.Height = 165;
                    i.Margin = new Thickness(5, 5, 5, 5);
                    i.VerticalAlignment = VerticalAlignment.Center;
                    i.Stretch = Stretch.Uniform;
                    if (p.Slika != null)
                    {
                        BitmapImage src = new BitmapImage();
                        src.BeginInit();
                        src.UriSource = new Uri(p.Slika, UriKind.Relative);
                        src.CacheOption = BitmapCacheOption.OnLoad;
                        src.EndInit();
                        i.Source = src;
                    }

                    TextBox tb = new TextBox()
                    {
                        IsEnabled = false,
                        TextWrapping = TextWrapping.Wrap,
                        Text = p.Opis + ", " + p.Cena + " dinara, "+p.Saradnik.Naziv,
                        Width = 330,
                        Height = 90,
                        Margin = new Thickness(10, 10, 10, 10),
                        Foreground = new SolidColorBrush(Colors.Black),
                        TextAlignment = TextAlignment.Center,
                        FontSize = 16,
                        VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        AcceptsReturn = true
                    };

                    Button b = new Button();
                    b.Width = 200;
                    b.Height = 65;
                    b.Margin = new Thickness(5, 5, 5, 5);
                    b.VerticalAlignment = VerticalAlignment.Center;
                    b.Content = "Pridruzi ponudu";
                    b.Tag = p;
                    b.Click += (object sender, RoutedEventArgs e) => {

                        Button odabran = (Button)sender;
                        Ponuda novap = (Ponuda)odabran.Tag;
                        Zadatak.Ponuda = novap;
                        Ponuda_Text.Text = novap.Opis + ", " + novap.Cena + " dinara, " + novap.Saradnik.Naziv;
                        Menjac.IsEnabled = true;

                    };


                    StackPanel sp = new StackPanel() { Orientation = Orientation.Vertical };
                    sp.Children.Add(i);
                    sp.Children.Add(tb);
                    sp.Children.Add(b);
                    

                    Grid g = new Grid();
                    g.Children.Add(sp);

                    card.Content = g;
                    wrapper.Children.Add(card);
                }
            }
        }

        private void Search_Changed(object sender, TextChangedEventArgs e)
        {
           
            this.Search = SearchBox.Text.ToLower();
            Dodaj_Ponude();
        }

        private void Menjac_Click(object sender, RoutedEventArgs e)
        {
            if (Naziv_Zadatka.Text == "")
            {
                MainWindow.notifier.ShowWarning("Naziv zadatka ne može biti prazan!");
                return;
            }
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Da li ste sigurni da želite da sačuvate izmene zadatka?", "Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            using(var db = new ProjectDatabase())
            {
                Zadatak nz = db.Zadaci.Find(Zadatak.Id);
                Ponuda np = db.Ponude.Find(Zadatak.Ponuda.Id);
                nz.Naziv = Naziv_Zadatka.Text;
                nz.Opis = Opis_Zadatka.Text;
                nz.Ponuda = np;
                db.SaveChanges();
            }
            MainWindow.notifier.ShowSuccess("Uspešno ste izmenili zadatak, bravo!");
            Menjac.IsEnabled = false;
        }

        private void Opis_Zadatka_TextChanged(object sender, TextChangedEventArgs e)
        {
            Menjac.IsEnabled = true;
        }

        private void Naziv_Zadatka_TextChanged(object sender, TextChangedEventArgs e)
        {
            Menjac.IsEnabled = true;
        }
    }
}
