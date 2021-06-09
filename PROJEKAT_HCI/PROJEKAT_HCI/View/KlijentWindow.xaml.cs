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
using MaterialDesignThemes.Wpf;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for KlijentWindow.xaml
    /// </summary>


    public partial class KlijentWindow : Window
    {
        public Klijent klijent { get; set; }


        public MainWindow Mw { get; set; }
        public KlijentWindow()
        {
            InitializeComponent();

        }
        public KlijentWindow(Klijent klijent)
        {
            this.klijent = klijent;
            DataContext = klijent;
            InitializeComponent();
          //  InitCard1();
          //  InitCard2();
          //  InitCard3();

        }
        public void InitTest()
        {
            Card card = new Card();
            card.Width = 220;
            card.Height = 220;
            card.Margin = new Thickness(5, 5, 5, 5);
            TextBox tb = new TextBox()
            {
                IsReadOnly = true,
                TextWrapping = TextWrapping.Wrap,
                //Text = p.Naziv,
                Width = 200,
                Height = 100,
                Margin = new Thickness(5, 5, 5, 5),
                Foreground = new SolidColorBrush(Colors.Black),
                TextAlignment = TextAlignment.Center,
                FontSize = 20,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalAlignment = VerticalAlignment.Stretch,
                AcceptsReturn = true
            };
            Button b = new Button();
            b.Content = "Pregled proslave";
            b.Width = 100;
            b.Height = 50;
            b.Margin = new Thickness(5, 5, 5, 5);
            //b.Proslava = p;
            b.VerticalAlignment = VerticalAlignment.Bottom;
            //wrapper.Children.Add(b);
            //b.Click += new RoutedEventHandler(Proslava_Btn_Click);
            Button b1 = new Button();
            //b1.Proslava = p;
            b1.Content = "Ponude proslave";
            b1.Width = 100;
            b1.Height = 50;
            b1.Margin = new Thickness(5, 20, 5, 5);
            b1.VerticalAlignment = VerticalAlignment.Bottom;
            //wrapper.Children.Add(b1);
            //b1.Click += new RoutedEventHandler(Ponude_Btn_Click);
            StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
            sp.Children.Add(b);
            sp.Children.Add(b1);
            StackPanel sp1 = new StackPanel() { Orientation = Orientation.Vertical };
            sp1.Margin = new Thickness(0, 0, 0, 10);
            sp1.Children.Add(tb);
            Grid g = new Grid();
            g.Children.Add(sp1);
            g.Children.Add(sp);

            card.Content = g;
           // wrapper.Children.Add(card);
        }
        public void InitCard1()
        {
            Card card = new Card();
            card.Width = 340;
            card.Height = 300;
            card.Margin = new Thickness(5, 5, 5, 5);

            Image i = new Image
            {
                Width = 200,
                Height = 165,
                Margin = new Thickness(5, 5, 5, 5),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Uniform
            };

            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("../../Res/Images/klijentSlika1.jpg", UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            i.Source = src;

            TextBox tb = new TextBox()
            {
                IsEnabled = false,
                TextWrapping = TextWrapping.Wrap,
                Width = 200,
                Height = 100,
                Margin = new Thickness(5, 5, 5, 5),
                Foreground = new SolidColorBrush(Colors.Black),
                TextAlignment = TextAlignment.Center,
                FontSize = 20,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalAlignment = VerticalAlignment.Stretch,
                AcceptsReturn = true
            };
            Button b = new Button();
            b.Content = "Nova proslava";
            b.Width = 200;
            b.Height = 50;
            b.Margin = new Thickness(5, 5, 5, 5);
            b.Click += new RoutedEventHandler(NovaProslavaBtn_Click);
            b.VerticalAlignment = VerticalAlignment.Bottom;

            StackPanel sp = new StackPanel() { Orientation = Orientation.Vertical };
            sp.Children.Add(i);
            sp.Children.Add(b);

            Grid g = new Grid();
            g.Children.Add(sp);

            card.Content = g;
          //  wrapper.Children.Add(card);
        }
        public void InitCard2()
        {
            Card card = new Card();
            card.Width = 340;
            card.Height = 300;
            card.Margin = new Thickness(5, 5, 5, 5);

            Image i = new Image
            {
                Width = 200,
                Height = 165,
                Margin = new Thickness(5, 5, 5, 5),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Uniform
            };

            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("../../Res/Images/klijentSlika1.jpg", UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            i.Source = src;

            TextBox tb = new TextBox()
            {
                IsEnabled = false,
                TextWrapping = TextWrapping.Wrap,
                Width = 200,
                Height = 100,
                Margin = new Thickness(5, 5, 5, 5),
                Foreground = new SolidColorBrush(Colors.Black),
                TextAlignment = TextAlignment.Center,
                FontSize = 20,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalAlignment = VerticalAlignment.Stretch,
                AcceptsReturn = true
            };
            Button b = new Button();
            b.Content = "Pregled proslava";
            b.Width = 200;
            b.Height = 50;
            b.Margin = new Thickness(5, 5, 5, 5);
            b.Click += new RoutedEventHandler(PregledProslavaBtn_Click);
            b.VerticalAlignment = VerticalAlignment.Bottom;

            StackPanel sp = new StackPanel() { Orientation = Orientation.Vertical };
            sp.Children.Add(i);
            sp.Children.Add(b);

            Grid g = new Grid();
            g.Children.Add(sp);

            card.Content = g;
           // wrapper.Children.Add(card);
        }
        public void InitCard3()
        {
            Card card = new Card();
            card.Width = 340;
            card.Height = 300;
            card.Margin = new Thickness(5, 5, 5, 5);

            Image i = new Image
            {
                Width = 200,
                Height = 165,
                Margin = new Thickness(5, 5, 5, 5),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Uniform
            };

            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("../../Res/Images/klijentSlika1.jpg", UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            i.Source = src;

            TextBox tb = new TextBox()
            {
                IsEnabled = false,
                TextWrapping = TextWrapping.Wrap,
                Width = 200,
                Height = 100,
                Margin = new Thickness(5, 5, 5, 5),
                Foreground = new SolidColorBrush(Colors.Black),
                TextAlignment = TextAlignment.Center,
                FontSize = 20,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalAlignment = VerticalAlignment.Stretch,
                AcceptsReturn = true
            };
            Button b = new Button();
            b.Content = "Pregled odrzanih proslava";
            b.Width = 200;
            b.Height = 50;
            b.Margin = new Thickness(5, 5, 5, 5);
            b.Click += new RoutedEventHandler(NovaProslavaBtn_Click);
            b.VerticalAlignment = VerticalAlignment.Bottom;

            StackPanel sp = new StackPanel() { Orientation = Orientation.Vertical };
            sp.Children.Add(i);
            sp.Children.Add(b);

            Grid g = new Grid();
            g.Children.Add(sp);

            card.Content = g;
            //wrapper.Children.Add(card);
        }
        private void NovaProslavaBtn_Click(object sender, RoutedEventArgs e)
        {
            NovaProslavaWindow npw = new NovaProslavaWindow(klijent);
            npw.Show();
            this.Close();
        }
        private void PregledProslavaBtn_Click(object sender, RoutedEventArgs e)
        {
            PregledProslavaWindow ppw = new PregledProslavaWindow(klijent);
            ppw.Show();
            this.Close();
        }
        private void PregledPonudaBtn_Click(object sender, RoutedEventArgs e)
        {
            PregledPonudaWindow ppw = new PregledPonudaWindow(klijent);
            ppw.Show();
            this.Close();
        }
        private void OdjavaBtn_Click(object sender, RoutedEventArgs e)
        {
            //klijent = null;
            MainWindow mv = new MainWindow();
            mv.Show();
            this.Close();
            

        }
        public String welcomeMessage()
        {
            return ("Dobrodosli, " + klijent.Ime + " " + klijent.Prezime);
        }
        private String getName(object sender, RoutedEventArgs e)
        {
            return klijent.Ime;
        }

        private void UrediProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            EditProfile ep = new EditProfile(this, klijent);
            ep.Show();
            this.Hide();
        }
    }
}
