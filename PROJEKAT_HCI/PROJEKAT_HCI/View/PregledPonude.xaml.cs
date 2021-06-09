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

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for PregledPonude.xaml
    /// </summary>
    public partial class PregledPonude : Window
    {
        private Proslava proslava;
        private Klijent klijent;

        public PregledPonude()
        {
            InitializeComponent();
        }
        public ObservableCollection<Zadatak> ZadaciView
        {
            get;
            set;
        }
        public PregledPonude(Proslava proslava, Klijent klijent)
        {

            this.proslava = proslava;
            this.klijent = klijent;
            InitializeComponent();
            this.DataContext = this;
            OpisProslave.Text = proslava.Opis;
            List<Zadatak> zadaci = new List<Zadatak>();
            using (var db = new ProjectDatabase())
            {
                zadaci = db.Proslave.Find(proslava.Id).PredlogProslave.Zadaci;
                if(zadaci == null)
                {
                    Label l = new Label();
                    l.Content = "Nemate jos uvek ponude za ovu proslavu";
                }
                foreach (Zadatak z in zadaci)
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
                        Text = "Opis ponude : "+ z.Ponuda.Opis + "\n" + "Cena: " + z.Ponuda.Cena,

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
                    Button b = new Button();
                    b.Width = 50;
                    b.Height = 50;
                    b.Margin = new Thickness(0, 0, 150, 0);
                    Viewbox viewbox = new Viewbox();
                    PackIcon packIcon = new PackIcon();
                    packIcon.Kind = PackIconKind.Check;
                    viewbox.Child = packIcon;
                    b.Content = viewbox;
                    /////
                    Button b1 = new Button();
                    b1.Width = 50;
                    b1.Height = 50;
                    Viewbox viewbox1 = new Viewbox();
                    PackIcon packIcon1 = new PackIcon();
                    packIcon1.Kind = PackIconKind.Denied;
                    viewbox1.Child = packIcon1;
                    b1.Content = viewbox1;
                    ///
                    Button b2 = new Button();
                    b2.Width = 50;
                    b2.Height = 50;
                    b2.Margin = new Thickness(150,0, 0, 0);
                    Viewbox viewbox2 = new Viewbox();
                    PackIcon packIcon2 = new PackIcon();
                    packIcon2.Kind = PackIconKind.Comment;
                    viewbox2.Child = packIcon2;
                    b2.Content = viewbox2;
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
            }

            ZadaciView = new ObservableCollection<Zadatak>(zadaci);

           // View = CollectionViewSource.GetDefaultView(Ponude);


        }
        private StackPanel PostaviOdg()
        {
            Button accept = new Button();
            Button decline = new Button();
            Button comment = new Button();
            accept.Content = "Prihvati";
            decline.Content = "Odustnai";
            comment.Content ="1231";
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            sp.Children.Add(accept);
            sp.Children.Add(decline);
            sp.Children.Add(comment);
            return sp;
        }
        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                    row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }
        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow(klijent);
            kw.Show();
            this.Hide();
        }
    }
}
