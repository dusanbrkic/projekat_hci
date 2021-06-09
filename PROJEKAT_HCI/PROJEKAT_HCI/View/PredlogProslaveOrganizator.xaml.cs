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
using MaterialDesignThemes.Wpf;
using ToastNotifications.Messages;
using WPFCustomMessageBox;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for PredlogProslaveOrganizator.xaml
    /// </summary>
    public partial class PredlogProslaveOrganizator : Window
    {
        public OrganizatorProslava op { get; set; }
        public Proslava Proslava { get; set; }
        public PredlogProslaveOrganizator(Proslava p, OrganizatorProslava parent)
        {
            this.Proslava = p;
            this.op = parent;
            InitializeComponent();
            using (var db = new ProjectDatabase())
            {
                Proslava pros = db.Proslave.Find(Proslava.Id);
                PredlogProslave pp = db.Predlozi.Find(pros.PredlogProslave.Id);
                Opis.Text = pp.Opis;
                KomentarKlijenta.Text = pp.KomentarKlijenta;
                foreach (var z in (from zad in db.Zadaci where
                                   (((zad.Status == Status_Zadatka.ZA_POSLATI) || (zad.Status == Status_Zadatka.PRIHVACENO)) &&
                                   (zad.PredlogProslave.Id==pp.Id)) select zad )  )
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
                        IsEnabled = false,
                        TextWrapping = TextWrapping.Wrap,
                        Text = "Zadatak: "+z.Naziv+" "+z.Ponuda.Opis + ", " + z.Ponuda.Cena + " dinara, " + z.Ponuda.Saradnik.Naziv,
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



                    StackPanel sp = new StackPanel() { Orientation = Orientation.Vertical };
                    sp.Children.Add(i);
                    sp.Children.Add(tb);


                    Grid g = new Grid();
                    g.Children.Add(sp);

                    card.Content = g;
                    wrapper.Children.Add(card);
                }

            }
                
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            op.Dodaj_Zadatke();
            op.Show();
        }

        private void Predlog_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = CustomMessageBox.ShowYesNo("Da li sigurno želite da pošaljete ovaj predlog klijentu?", "Potvrda", "Da", "Ne");
            if (res == MessageBoxResult.No)
            {
                return;
            }
            using (var db = new ProjectDatabase())
            {
                Proslava pros = db.Proslave.Find(Proslava.Id);
                PredlogProslave pp = db.Predlozi.Find(pros.PredlogProslave.Id);
                foreach (var z in (from zad in db.Zadaci where
                        (((zad.Status == Status_Zadatka.ZA_POSLATI)) &&
                            (zad.PredlogProslave.Id == pp.Id))select zad))
                {
                    z.Status = Status_Zadatka.POSLATO;
                    pp.Opis = Opis.Text;
                    
                }
                db.SaveChanges();

            }
            MainWindow.notifier.ShowSuccess("Čestitamo uspešno ste napravili predlog proslave!");
            this.Close();
            op.Dodaj_Zadatke();
            op.Show();
        }
    }
}
