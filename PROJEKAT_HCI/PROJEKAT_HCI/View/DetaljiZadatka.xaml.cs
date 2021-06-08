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
using PROJEKAT_HCI.Model;
using PROJEKAT_HCI.Database;
using MaterialDesignThemes.Wpf;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for DetaljiZadatka.xaml
    /// </summary>
    public partial class DetaljiZadatka : Window
    {
        public OrganizatorProslava op { get; set; }
        public Zadatak Zadatak;
        public DetaljiZadatka(Zadatak z, OrganizatorProslava op)
        {
            this.Zadatak = z;
            this.op = op;
            InitializeComponent();
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
                foreach (var p in db.Ponude)
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
                        Text = p.Opis + ", " + p.Cena + " dinara.",
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
    }
}
