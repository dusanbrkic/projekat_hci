using PROJEKAT_HCI.Database;
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
    /// Interaction logic for PregledProslavaWindow.xaml
    /// </summary>
    public partial class PregledProslavaWindow : Window
    {
        private Klijent klijent { get; set; }
        public class Dugme : Button
        {
            public Proslava Proslava { get; set; }
        }
        public PregledProslavaWindow(Klijent k)
        {
            InitializeComponent();
            this.klijent = k;
            using (var db = new ProjectDatabase())
            {
                //var proslave = (from p in db.Proslave where p.Klijent.Id == klijent.Id select p);
                foreach (Proslava p in (from p in db.Proslave where p.Klijent.Id == klijent.Id && p.StatusProslave != StatusProslave.OTKAZANA && p.StatusProslave != StatusProslave.ORGANIZOVANO select p).ToList())
                {
                    Card card = new Card();
                    card.Width = 220;
                    card.Height = 220;
                    card.Margin = new Thickness(5, 5, 5, 5);
                    TextBox tb = new TextBox()
                    {
                        IsReadOnly = true,
                        TextWrapping = TextWrapping.Wrap,
                        Text = p.Naziv,
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
                    Dugme b = new Dugme();
                    b.Content = "Pregled proslave";
                    b.Width = 100;
                    b.Height = 50;
                    b.Margin = new Thickness(5, 5, 5, 5);
                    var bc = new BrushConverter();
                    b.Background = (Brush) bc.ConvertFrom("#673ab7");
                    b.Foreground = Brushes.White;
                    b.Proslava = p;
                    b.VerticalAlignment = VerticalAlignment.Bottom;
                    //wrapper.Children.Add(b);
                    b.Click += new RoutedEventHandler(Proslava_Btn_Click);
                    Dugme b1 = new Dugme();
                    b1.Proslava = p;
                    b1.Content = "Ponude proslave";
                    b1.Width = 100;
                    b1.Height = 50;
                    b1.Margin = new Thickness(5, 20, 5, 5);
                    b1.Background = (Brush)bc.ConvertFrom("#673ab7");
                    b1.Foreground = Brushes.White;
                    b1.VerticalAlignment = VerticalAlignment.Bottom;
                    //wrapper.Children.Add(b1);
                    b1.Click += new RoutedEventHandler(Ponude_Btn_Click);
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
                    wrapper.Children.Add(card);
                }
                /*                foreach (Proslava p in db.Proslave)
                                {

                                }*/
            }
        }

        private void Proslava_Btn_Click(object sender, RoutedEventArgs e)
        {
            Dugme b = (Dugme)sender;
            PregledProslave pp = new PregledProslave(b.Proslava, klijent);
            pp.Show();
            this.Hide();
        }
        private void Ponude_Btn_Click(object sender, RoutedEventArgs e)
        {
            Dugme b = (Dugme)sender;
            PregledPonude pp = new PregledPonude(b.Proslava, klijent);
            pp.Show();
            this.Hide();
        }
        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow(klijent);
            kw.Show();
            this.Close();
        }

        private void PretragaBtn_Click(object sender, RoutedEventArgs e)
        {
            wrapper.Children.Clear();
            using (var db = new ProjectDatabase())
            {
                foreach (Proslava p in (from p in db.Proslave where p.Klijent.Id == klijent.Id && p.Naziv.Contains(search.Text) && p.StatusProslave != StatusProslave.OTKAZANA && p.StatusProslave != StatusProslave.ORGANIZOVANO select p).ToList())
                {
                    Card card = new Card();
                    card.Width = 220;
                    card.Height = 220;
                    card.Margin = new Thickness(5, 5, 5, 5);
                    TextBox tb = new TextBox()
                    {
                        IsEnabled = false,
                        TextWrapping = TextWrapping.Wrap,
                        Text = p.Naziv,
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
                    BrushConverter bc = new BrushConverter();
                    Dugme b = new Dugme();
                    b.Content = "Pregled proslave";
                    b.Width = 100;
                    b.Height = 50;
                    b.Proslava = p;
                    b.Margin = new Thickness(5, 5, 5, 5);
                    b.VerticalAlignment = VerticalAlignment.Bottom;
                    b.Background = (Brush)bc.ConvertFrom("#673ab7");
                    b.Foreground = Brushes.White;
                    //wrapper.Children.Add(b);
                    b.Click += new RoutedEventHandler(Proslava_Btn_Click);
                    Dugme b1 = new Dugme();
                    b1.Content = "Ponude proslave";
                    b1.Width = 100;
                    b1.Height = 50;
                    b1.Margin = new Thickness(5, 20, 5, 5);
                    b1.VerticalAlignment = VerticalAlignment.Bottom;
                    b1.Proslava = p;
                    b1.Background = (Brush)bc.ConvertFrom("#673ab7");
                    b1.Foreground = Brushes.White;
                    //wrapper.Children.Add(b1);
                    b1.Click += new RoutedEventHandler(Ponude_Btn_Click);
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
                    wrapper.Children.Add(card);
                }
            }

        }

        private void UrediProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            EditProfile ep = new EditProfile(this, klijent);
            ep.Show();
            this.Hide();
        }
    }
}
