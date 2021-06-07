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
using MaterialDesignThemes.Wpf;
using PROJEKAT_HCI.Database;
using PROJEKAT_HCI.Model;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for ObavestenjaWindow.xaml
    /// </summary>
    public partial class ObavestenjaWindow : Window
    {
        public Organizator Organizator { get; set; }
        public Window OrganizatorWindow { get; set; }

        public ObavestenjaWindow(Organizator org, Window ow)
        {
            Organizator = org;
            OrganizatorWindow = ow;

            InitializeComponent();

            using (var db = new ProjectDatabase()) {

               var obavestenja = from obavestenje in db.Obavestenja
                               where obavestenje.PredlogProslave.Proslava.Organizator.Id == Organizator.Id
                               orderby obavestenje.TimeStamp descending
                               select obavestenje;

                if (obavestenja == null)
                    return;

                foreach (var obavestenje in obavestenja)
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
                    b.Tag = obavestenje;
                    b.Click += (object sender, RoutedEventArgs e) => {
                        obavestenje.Procitano = true;
                        //TODO otvoriti prozor organizovanja proslave
                    };

                    TextBox tb = new TextBox() {
                        IsEnabled = false,
                        TextWrapping = TextWrapping.Wrap,
                        Text = obavestenje.Sadrzaj + "\nProslava: " +
                            obavestenje.PredlogProslave.Proslava.Naziv + "\nVreme: " + obavestenje.TimeStamp,
                        Width = 330,
                        Height = 90,
                        Margin = new Thickness(10,10,10,10),
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
            this.Hide();
            OrganizatorWindow.Show();
        }
    }
}
