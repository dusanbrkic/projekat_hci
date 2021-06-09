using MaterialDesignThemes.Wpf;
using PROJEKAT_HCI.Database;
using PROJEKAT_HCI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFCustomMessageBox;
using MaterialDesignThemes.Wpf;
using Microsoft.VisualBasic;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for PregledPonude.xaml
    /// </summary>
    public partial class PregledPonude : Window
    {
        private Proslava proslava;
        private Klijent klijent;
        private List<Card> cards;
        private List<Zadatak> zadaci;
        public PregledPonude()
        {
            InitializeComponent();
        }
        public ObservableCollection<Zadatak> ZadaciView
        {
            get;
            set;
        }
        public ObservableCollection<Ponuda> Ponude
        {
            get;
            set;
        }
        public class Dugme: Button
        {
            public Zadatak Zadatak { get; set; }
        }
        public PregledPonude(Proslava proslava, Klijent klijent)
        {
            this.proslava = proslava;
            this.klijent = klijent;
            InitializeComponent();
            this.DataContext = this;
            
            
            zadaci = new List<Zadatak>();
            using (var db = new ProjectDatabase())
            {
                OpisProslave.Text = db.Proslave.Find(proslava.Id).PredlogProslave.Opis;
                zadaci = db.Proslave.Find(proslava.Id).PredlogProslave.Zadaci;
                if (zadaci == null)
                {
                    Label l = new Label();
                    l.Content = "Nemate jos uvek ponude za ovu proslavu";
                    wrapper.Children.Add(l);
                }
                foreach (Zadatak z in zadaci)
                {
                    if (z.Status != Status_Zadatka.ODBIJENO)
                    {

                        if (z.Status == Status_Zadatka.PRIHVACENO)
                        {
                            prihvacenoKartica(z);
                        }
                        else if (z.Status == Status_Zadatka.ZA_IZMENU)
                        {
                            zaIzmenuKartica(z);
                        }
                        else if (z.Status == Status_Zadatka.POSLATO)
                        {
                            defaultKartica(z);
                        }
                    }
                }
            }
        }
        private void zaIzmenuKartica(Zadatak z)
        {
            Card card = new Card();
            card.Width = 340;
            card.Height = 300;
            card.Margin = new Thickness(5, 5, 5, 5);
            card.Background = Brushes.LightGray;
            Image i = new Image();
            i.Width = 200;
            i.Height = 165;
            i.Margin = new Thickness(5, 5, 5, 5);
            i.VerticalAlignment = VerticalAlignment.Center;
            i.Stretch = Stretch.Uniform;
            if (z.Ponuda.Slika != null)
            {
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(z.Ponuda.Slika, UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                i.Source = src;
            }

            TextBox tb = new TextBox()
            {
                IsReadOnly = true,
                TextWrapping = TextWrapping.Wrap,
                Text = "Opis ponude : " + z.Ponuda.Opis + "\n" + "Cena: " + z.Ponuda.Cena,

                Width = 330,
                Height = 45,
                Margin = new Thickness(10, 10, 10, 10),
                Foreground = new SolidColorBrush(Colors.Black),
                TextAlignment = TextAlignment.Center,
                FontSize = 16,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalAlignment = VerticalAlignment.Stretch,
                AcceptsReturn = true
            };
            Label l = new Label();
            Dugme b = new Dugme();
            b.Zadatak = z;
            b.Width = 50;
            b.Height = 50;
            b.Margin = new Thickness(0, 0, 150, 0);
            b.Click += new RoutedEventHandler(prihvatiPonudu);
            Viewbox viewbox = new Viewbox();
            PackIcon packIcon = new PackIcon();
            packIcon.Kind = PackIconKind.Check;
            viewbox.Child = packIcon;
            b.Content = viewbox;


            Dugme b1 = new Dugme();
            b1.Zadatak = z;
            b1.Width = 50;
            b1.Height = 50;
            b1.Click += new RoutedEventHandler(OdbijPonudu);
            Viewbox viewbox1 = new Viewbox();
            PackIcon packIcon1 = new PackIcon();
            packIcon1.Kind = PackIconKind.Denied;
            viewbox1.Child = packIcon1;
            b1.Content = viewbox1;
            ///



            Dugme b2 = new Dugme();
            b2.Width = 50;
            b2.Height = 50;
            b2.Margin = new Thickness(150, 0, 0, 0);
            b2.Zadatak = z;
            Viewbox viewbox2 = new Viewbox();
            PackIcon packIcon2 = new PackIcon();
            packIcon2.Kind = PackIconKind.Comment;
            viewbox2.Child = packIcon2;
            b2.Content = viewbox2;
            b2.Click += new RoutedEventHandler(komentarPonude);
            Grid g1 = new Grid();
            g1.Children.Add(b);
            g1.Children.Add(b1);
            g1.Children.Add(b2);
            StackPanel sp = new StackPanel() { Orientation = Orientation.Vertical };
            sp.Children.Add(i);
            sp.Children.Add(tb);
            sp.Children.Add(g1);
            Grid g = new Grid();
            g.Children.Add(sp);

            card.Content = g;
            wrapper.Children.Add(card);
        }
        private void prihvacenoKartica(Zadatak z)
        {
            Card card = new Card();
            card.Width = 340;
            card.Height = 300;
            card.Margin = new Thickness(5, 5, 5, 5);
            card.BorderBrush = Brushes.Green;
            card.BorderThickness = new Thickness(10);
            //card.Background = Brushes.Green;
            Image i = new Image();
            i.Width = 200;
            i.Height = 165;
            i.Margin = new Thickness(5, 5, 5, 5);
            i.VerticalAlignment = VerticalAlignment.Center;
            i.Stretch = Stretch.Uniform;
            if (z.Ponuda.Slika != null)
            {
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(z.Ponuda.Slika, UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                i.Source = src;
            }

            TextBox tb = new TextBox()
            {
                IsReadOnly = true,
                TextWrapping = TextWrapping.Wrap,
                Text = "Opis ponude : " + z.Ponuda.Opis + "\n" + "Cena: " + z.Ponuda.Cena,

                Width = 330,
                Height = 45,
                Margin = new Thickness(10, 10, 10, 10),
                Foreground = new SolidColorBrush(Colors.Black),
                TextAlignment = TextAlignment.Center,
                FontSize = 16,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalAlignment = VerticalAlignment.Stretch,
                AcceptsReturn = true
            };
            Grid g1 = new Grid();
            Label l = new Label
            {
                Width = 300,
                Height = 50,
                Content = "Prihvaceno",
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.White,
                Background = Brushes.Green
            };
            StackPanel sp = new StackPanel() { Orientation = Orientation.Vertical };
            sp.Children.Add(i);
            sp.Children.Add(tb);
            sp.Children.Add(l);
            Grid g = new Grid();
            g.Children.Add(sp);
            
            card.Content = g;
            wrapper.Children.Add(card);
        }
        private void defaultKartica(Zadatak z)
        {
            Card card = new Card();
            card.Width = 340;
            card.Height = 300;
            card.Margin = new Thickness(5, 5, 5, 5);
            Image i = new Image();
            i.Width = 200;
            i.Height = 165;
            i.Margin = new Thickness(5, 5, 5, 5);
            i.VerticalAlignment = VerticalAlignment.Center;
            i.Stretch = Stretch.Uniform;
            if (z.Ponuda.Slika != null)
            {
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(z.Ponuda.Slika, UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                i.Source = src;
            }

            TextBox tb = new TextBox()
            {
                IsReadOnly = true,
                TextWrapping = TextWrapping.Wrap,
                Text = "Opis ponude : " + z.Ponuda.Opis + "\n" + "Cena: " + z.Ponuda.Cena,

                Width = 330,
                Height = 45,
                Margin = new Thickness(10, 10, 10, 10),
                Foreground = new SolidColorBrush(Colors.Black),
                TextAlignment = TextAlignment.Center,
                FontSize = 16,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalAlignment = VerticalAlignment.Stretch,
                AcceptsReturn = true
            };
            Label l = new Label();
            Dugme b = new Dugme();
            b.Zadatak = z;
            b.Width = 50;
            b.Height = 50;
            b.Margin = new Thickness(0, 0, 150, 0);
            b.Click += new RoutedEventHandler(prihvatiPonudu);
            Viewbox viewbox = new Viewbox();
            PackIcon packIcon = new PackIcon();
            packIcon.Kind = PackIconKind.Check;
            viewbox.Child = packIcon;
            b.Content = viewbox;


            Dugme b1 = new Dugme();
            b1.Zadatak = z;
            b1.Width = 50;
            b1.Height = 50;
            b1.Click += new RoutedEventHandler(OdbijPonudu);
            Viewbox viewbox1 = new Viewbox();
            PackIcon packIcon1 = new PackIcon();
            packIcon1.Kind = PackIconKind.Denied;
            viewbox1.Child = packIcon1;
            b1.Content = viewbox1;
            ///



            Dugme b2 = new Dugme();
            b2.Width = 50;
            b2.Height = 50;
            b2.Margin = new Thickness(150, 0, 0, 0);
            b2.Zadatak = z;
            Viewbox viewbox2 = new Viewbox();
            PackIcon packIcon2 = new PackIcon();
            packIcon2.Kind = PackIconKind.Comment;
            viewbox2.Child = packIcon2;
            b2.Content = viewbox2;
            b2.Click += new RoutedEventHandler(komentarPonude);
            Grid g1 = new Grid();
            g1.Children.Add(b);
            g1.Children.Add(b1);
            g1.Children.Add(b2);
            StackPanel sp = new StackPanel() { Orientation = Orientation.Vertical };
            sp.Children.Add(i);
            sp.Children.Add(tb);
            sp.Children.Add(g1);
            Grid g = new Grid();
            g.Children.Add(sp);

            card.Content = g;
            wrapper.Children.Add(card);
        }

        private void komentarPonude(object sender, RoutedEventArgs e)
        {
            Dugme b = (Dugme)sender;
            using (var db = new ProjectDatabase())
            {
                Zadatak zad = (Zadatak)(from z in db.Zadaci where z.Id == b.Zadatak.Id select z).FirstOrDefault();
                Proslava p = db.Proslave.Find(proslava.Id);
                string odg = Interaction.InputBox("Unesite komentar", "Komentar", "", 500, 300);

                if (odg.Equals(""))
                {
                    MainWindow.notifier.ShowWarning("Niste uneli komentar!");
                    return;
                }

                
                zad.Status = Status_Zadatka.ZA_IZMENU;
                zad.KomentarKlijenta = odg;
                db.SaveChanges();
                wrapper.Children.Clear();
                refreshCards();
                MainWindow.notifier.ShowSuccess("Poslali ste komentar!");
            }


        }

        private void OdbijPonudu(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Da li sigurni da zelite da odbijete ponudu?", "Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            if (res == MessageBoxResult.Yes)
            {
                Dugme b = (Dugme)sender;
                using (var db = new ProjectDatabase())
                {

                    Proslava p = db.Proslave.Find(proslava.Id);

                    Zadatak zad = (Zadatak)(from z in db.Zadaci where z.Id == b.Zadatak.Id select z).FirstOrDefault();
                    zad.Status = Status_Zadatka.ODBIJENO;

                    db.SaveChanges();
                    wrapper.Children.Clear();
                    refreshCards();
                    MainWindow.notifier.ShowSuccess("Odbili ste ponudu!");
                }
            }


        }

        
        private void prihvatiPonudu(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Da li sigurni da zelite da potvrdite ponudu?", "Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            if (res == MessageBoxResult.Yes)
            {
                Dugme b = (Dugme)sender;
                using (var db = new ProjectDatabase())
                {
                    Proslava p = db.Proslave.Find(proslava.Id);

                    Zadatak zad = (Zadatak)(from z in db.Zadaci where z.Id == b.Zadatak.Id select z).FirstOrDefault();
                    zad.Status = Status_Zadatka.PRIHVACENO;

                    db.SaveChanges();
                    wrapper.Children.Clear();
                    refreshCards();
                }
                MainWindow.notifier.ShowSuccess("Potvrdili ste ponudu!");
            }


        }
        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow(klijent);
            kw.Show();
            this.Hide();
        }

        private void refreshCards()
        {
            List<Zadatak> zadaci = new List<Zadatak>();
            using (var db = new ProjectDatabase())
            {
                zadaci = db.Proslave.Find(proslava.Id).PredlogProslave.Zadaci;
                if (zadaci == null)
                {
                    Label l = new Label();
                    l.Content = "Nemate jos uvek ponude za ovu proslavu";
                }
                foreach (Zadatak z in zadaci)
                {
                    if (z.Status != Status_Zadatka.ODBIJENO)
                    {

                        if (z.Status == Status_Zadatka.PRIHVACENO)
                        {
                            prihvacenoKartica(z);
                        }
                        else if (z.Status == Status_Zadatka.ZA_IZMENU)
                        {
                            zaIzmenuKartica(z);
                        }
                        else if (z.Status == Status_Zadatka.POSLATO)
                        {
                            defaultKartica(z);
                        }
                    }
                }

                Ponude = new ObservableCollection<Ponuda>((from p in db.Ponude select p).ToList());
                ZadaciView = new ObservableCollection<Zadatak>(zadaci);
            }
        }

        private void KomentarPonuduBtn_Click(object sender, RoutedEventArgs e)
        {
            string odg = Interaction.InputBox("Unesite komentar", "Komentar", "", 500, 300);

            if (odg.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Niste uneli komentar!");
                return;
            }
            using (var db = new ProjectDatabase())
            {
                db.Proslave.Find(proslava.Id).PredlogProslave.KomentarKlijenta = odg;
                MainWindow.notifier.ShowWarning("Poslat komentar za opis ponude!");
                db.SaveChanges();
            }
        }

        private void OdbijPonuduBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Da li ste sigurni da zelite da odbijete opis proslave?", "Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            if (res == MessageBoxResult.Yes)
            {
                using (var db = new ProjectDatabase())
                {
                    db.Proslave.Find(proslava.Id).PredlogProslave.Prihvacen = false;

                    MainWindow.notifier.ShowWarning("Odbili ste opis ponude!");
                    db.SaveChanges();
                }
            }
        }

        private void PrihvatiPonuduBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Da li ste sigurni da zelite da potvrdite opis proslave?", "Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            if (res == MessageBoxResult.Yes)
            {
                using (var db = new ProjectDatabase())
                {
                    db.Proslave.Find(proslava.Id).PredlogProslave.Prihvacen = true;
                    MainWindow.notifier.ShowWarning("Prihvatili ste opis ponude!");
                    db.SaveChanges();
                }
            }
        }

        private void PotvrdiZahtevBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Da li ste sigurni da zelite da potvrdite zahtev?", "Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            if (res == MessageBoxResult.Yes)
            {
                foreach (Zadatak zadatak in zadaci)
                {
                    using (var db = new ProjectDatabase())
                    {
                        Proslava p = db.Proslave.Find(proslava.Id);

                        Zadatak zad = (Zadatak)(from z in db.Zadaci where z.Id == zadatak.Id select z).FirstOrDefault();
                        if(zad.Status != Status_Zadatka.ODBIJENO)
                        {
                            zad.Status = Status_Zadatka.PRIHVACENO;
                            db.SaveChanges();
                        }

                    }
                }
            }
            refreshCards();
        }
    }
}
