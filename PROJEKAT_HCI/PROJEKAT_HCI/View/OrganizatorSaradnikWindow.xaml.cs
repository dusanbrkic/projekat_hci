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
using PROJEKAT_HCI.View;
using PROJEKAT_HCI.Database;
using MaterialDesignThemes.Wpf;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for OrganizatorSaradnikWindow.xaml
    /// </summary>
    public partial class OrganizatorSaradnikWindow : Window
    {
        public Saradnik Saradnik { get; set; }
        public OrganizatorSaradnici os { get; set; }
        public OrganizatorSaradnikWindow(Saradnik s, OrganizatorSaradnici ost)
        {
            this.Saradnik = s;
            this.os = ost;
            InitializeComponent();
            this.Title = Saradnik.Naziv;
            Opis.Text = "Opis: " + Saradnik.Opis;
            Lokacija.Text = "Lokacija: " + Saradnik.Lokacija;
            Dodaj_Ponude();
            
        }

        public void Dodaj_Ponude()
        {
            Wrapper_ponuda.Children.Clear();
            using (var db = new ProjectDatabase())
            {
                foreach (var p in (from saradnik in db.Saradnici where saradnik.Id == this.Saradnik.Id select saradnik.Ponude).First())
                {   

                    //Label l = new Label();
                    //l.Content = p.Opis + ", " + p.Cena + " dinara.";
                    //l.Background = Brushes.DarkBlue;
                    //l.Foreground = Brushes.White;
                    //l.HorizontalContentAlignment = HorizontalAlignment.Center;
                    //l.VerticalContentAlignment = VerticalAlignment.Center;
                    //l.FontSize = 17;

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
                    if (p.Slika != null) {
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
                    Wrapper_ponuda.Children.Add(card);
                }
            }

        }

        private void Nazad_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            os.Show();
        }
        private void NovaPonuda_Btn_Click(object sender, RoutedEventArgs e)
        {
            NovaPonudaOrganizator npo = new NovaPonudaOrganizator(this, this.Saradnik);
            this.Hide();
            npo.Show();
        }


    }
}
