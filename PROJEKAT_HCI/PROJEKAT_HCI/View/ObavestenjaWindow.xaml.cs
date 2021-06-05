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
    /// Interaction logic for ObavestenjaWindow.xaml
    /// </summary>
    public partial class ObavestenjaWindow : Window
    {
        public ObavestenjaWindow()
        {
            InitializeComponent();

            var obavestenja = new List<Obavestenje>();

            using (var db = new ProjectDatabase()) {
                obavestenja = (List<Obavestenje>)(from obavestenje in db.Obavestenja
                               where obavestenje.Procitano == false &&
                               obavestenje.PredlogProslave.Proslava.Organizator == db.Organizatori.Find(1)
                               select obavestenje);
            }

            foreach (var obavestenje in obavestenja)
            {
                Button b = new Button();
                b.Width = 200;
                b.Height = 140;
                b.Margin = new Thickness(20);
                b.Content = obavestenje.Sadrzaj;
                wrapper.Children.Add(b);
            }
        }
    }
}
