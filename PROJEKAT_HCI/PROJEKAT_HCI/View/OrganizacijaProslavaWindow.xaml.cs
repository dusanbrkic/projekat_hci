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
        public OrganizacijaProslavaWindow(Organizator o)
        {
            InitializeComponent();

            Organizator = o;

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
                    Button b = new Button();
                    b.Width = 200;
                    b.Height = 140;
                    b.Margin = new Thickness(20);
                    b.Content = proslava.Naziv;
                    wrapper.Children.Add(b);
                    b.Tag = proslava;
                    b.Click += (object sender, RoutedEventArgs e) => {
                        
                    };
                }
            }
        }
    }
}
