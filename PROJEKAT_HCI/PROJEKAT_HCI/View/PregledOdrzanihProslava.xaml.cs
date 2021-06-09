using MaterialDesignThemes.Wpf;
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

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for PregledOdrzanihProslava.xaml
    /// </summary>
    public partial class PregledOdrzanihProslava : Window
    {
        public class Dugme : Button
        {
            public Proslava Proslava { get; set; }
        }
        private Klijent klijent { get; set; }
        public PregledOdrzanihProslava(Klijent k)
        {
            this.klijent = k;
            InitializeComponent();
            InitializeComponent();
            this.klijent = k;
            using (var db = new ProjectDatabase())
            {
                //var proslave = (from p in db.Proslave where p.Klijent.Id == klijent.Id select p);
                foreach (Proslava p in (from p in db.Proslave where p.Klijent.Id == klijent.Id && p.StatusProslave == StatusProslave.ORGANIZOVANO select p).ToList())
                {
                    int suma = 0;
                    ;
                    foreach (Zadatak z in db.Proslave.Find(p.Id).PredlogProslave.Zadaci)
                    {
                        suma += z.Ponuda.Cena;
                    }
                    Card card = new Card();
                    card.Width = 220;
                    card.Height = 220;
                    card.Margin = new Thickness(5, 5, 5, 5);
                    TextBox tb = new TextBox()
                    {
                        IsReadOnly = true,
                        TextWrapping = TextWrapping.Wrap,
                        Text = p.Naziv + "\n Cena: " + suma,
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
                    StackPanel sp1 = new StackPanel() { Orientation = Orientation.Vertical };
                    sp1.Margin = new Thickness(0, 0, 0, 10);
                    sp1.Children.Add(tb);
                    Grid g = new Grid();
                    g.Children.Add(sp1);

                    card.Content = g;
                    wrapper.Children.Add(card);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow(this.klijent);
            kw.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            wrapper.Children.Clear();
            using (var db = new ProjectDatabase())
            {
                foreach (Proslava p in (from p in db.Proslave where p.Klijent.Id == klijent.Id && p.Naziv.Contains(search.Text) && p.StatusProslave == StatusProslave.ORGANIZOVANO select p).ToList())
                {

                    int suma = 0;
                    ;
                    foreach (Zadatak z in db.Proslave.Find(p.Id).PredlogProslave.Zadaci)
                    {
                        suma += z.Ponuda.Cena;
                    }
                    Card card = new Card();
                    card.Width = 220;
                    card.Height = 220;
                    card.Margin = new Thickness(5, 5, 5, 5);
                    TextBox tb = new TextBox()
                    {
                        IsReadOnly = true,
                        TextWrapping = TextWrapping.Wrap,
                        Text = p.Naziv + "\n Cena: " + suma,
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
                    StackPanel sp1 = new StackPanel() { Orientation = Orientation.Vertical };
                    sp1.Margin = new Thickness(0, 0, 0, 10);
                    sp1.Children.Add(tb);
                    Grid g = new Grid();
                    g.Children.Add(sp1);

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
