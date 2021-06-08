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
        public void InitCards(String imagePath,String buttonText)
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
            src.UriSource = new Uri(imagePath, UriKind.Relative);
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
            b.Content = buttonText;
            b.Width = 200;
            b.Height = 50;
            b.Margin = new Thickness(5, 5, 5, 5);
            b.VerticalAlignment = VerticalAlignment.Bottom;

            //b.Click += new RoutedEventHandler(buttonPress);
            StackPanel sp = new StackPanel() { Orientation = Orientation.Vertical };
            sp.Children.Add(i);
            //sp.Children.Add(tb);
            sp.Children.Add(b);

            Grid g = new Grid();
            g.Children.Add(sp);

            card.Content = g;
            wrapper.Children.Add(card);
        }
        public KlijentWindow(Klijent klijent)
        {
            this.klijent = klijent;
            DataContext = klijent;
            InitializeComponent();

        }
        private void NovaProslavaBtn_Click(object sender, RoutedEventArgs e)
        {
            NovaProslavaWindow npw = new NovaProslavaWindow();
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
    }
}
