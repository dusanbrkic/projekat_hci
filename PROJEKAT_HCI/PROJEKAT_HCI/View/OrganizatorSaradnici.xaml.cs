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
using PROJEKAT_HCI.View;


namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for OrganizatorSaradnici.xaml
    /// </summary>
    public partial class OrganizatorSaradnici : Window
    {
        public OrganizatorWindow ow {get; set;}
        public OrganizatorSaradnici()
        {
            InitializeComponent();

            using (var db = new ProjectDatabase())
            {
                 foreach(Saradnik s in db.Saradnici.ToList())
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
                    b.Tag = s;
                    b.Click += Saradnik_Btn_Click;

                    TextBox tb = new TextBox()
                    {
                        IsEnabled = false,
                        TextWrapping = TextWrapping.Wrap,
                        Text = s.Naziv,
                        Width = 330,
                        Height = 90,
                        Margin = new Thickness(10, 10, 10, 10),
                        Foreground = new SolidColorBrush(Colors.Black),
                        TextAlignment = TextAlignment.Center,
                        FontSize = 20,
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

        private void Saradnik_Btn_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            //Console.WriteLine(((Saradnik)b.Tag).Opis);
            
            OrganizatorSaradnikWindow osw = new OrganizatorSaradnikWindow(((Saradnik)b.Tag), this);
            this.Hide();
            osw.Show();
        }

        private void Nazad_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ow.Show();
        }
    }
}
