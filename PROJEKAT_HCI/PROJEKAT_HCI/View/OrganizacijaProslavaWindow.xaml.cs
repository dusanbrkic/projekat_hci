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
using PROJEKAT_HCI.Database;
using PROJEKAT_HCI.Model;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for OrganizacijaProslavaWindow.xaml
    /// </summary>
    public partial class OrganizacijaProslavaWindow : Window
    {
        public Organizator Organizator { get; set; }
        public Window OrganizatorWindow { get; set; }
        public OrganizacijaProslavaWindow(Organizator o, Window ow)
        {
            InitializeComponent();

            Organizator = o;
            OrganizatorWindow = ow;

            using (var db = new ProjectDatabase())
            {

                var proslave = from proslava in db.Proslave
                                  where proslava.PredlogProslave.Proslava.Organizator.Id == Organizator.Id
                                  orderby proslava.DatumOdrzavanja descending
                                  select proslava;

                if (proslave == null)
                    return;

                foreach (var proslava in proslave)
                {
                    Card card = new Card();
                    card.Width = 340;
                    card.Height = 200;
                    card.Margin = new Thickness(5, 5, 5, 5);

                    Button b = new Button();
                    b.Width = 200;
                    b.Height = 65;
                    b.Margin = new Thickness(5, 5, 5, 5);
                    b.VerticalAlignment = VerticalAlignment.Center;
                    b.Content = "POGLEDAJ";
                    b.Tag = proslava;
                    b.Click += (object sender, RoutedEventArgs e) => {
                        //TODO otvoriti prozor organizovanja proslave
                        OrganizatorProslava pros = new OrganizatorProslava(this, proslava);
                        this.Hide();
                        pros.Show();

                    };

                    TextBox tb = new TextBox()
                    {
                        IsEnabled = false,
                        TextWrapping = TextWrapping.Wrap,
                        Text = proslava.Naziv + "\nDatum odrzavanja: " + proslava.DatumOdrzavanja,
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
                    sp.Children.Add(tb);
                    sp.Children.Add(b);

                    Grid g = new Grid();
                    g.Children.Add(sp);

                    card.Content = g;
                    wrapper.Children.Add(card);
                }
            }
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            OrganizatorWindow.Show();
            this.Hide();
        }
    }
}
