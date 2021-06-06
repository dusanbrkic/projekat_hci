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

        public ObavestenjaWindow(Organizator org)
        {
            Organizator = org;

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
                    Button b = new Button();
                    b.Width = 200;
                    b.Height = 140;
                    b.Margin = new Thickness(20);
                    if (obavestenje.Procitano == true)
                    {
                        b.Content = obavestenje.Sadrzaj + " za proslavu " +
                            obavestenje.PredlogProslave.Proslava.Naziv + '\n' + obavestenje.TimeStamp;
                    }
                    else if (obavestenje.Procitano == false) {
                        b.Content = "NOVO " + obavestenje.Sadrzaj + " za proslavu " +
                            obavestenje.PredlogProslave.Proslava.Naziv + '\n' + obavestenje.TimeStamp;
                    }
                        wrapper.Children.Add(b);
                    b.Tag = obavestenje;
                    b.Click += (object sender, RoutedEventArgs e) => {
                        obavestenje.Procitano = true;
                    };
                }
            }
        }
    }
}
