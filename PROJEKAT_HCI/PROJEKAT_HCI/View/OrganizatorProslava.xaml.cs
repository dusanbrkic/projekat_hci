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

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for OrganizatorProslava.xaml
    /// </summary>
    public partial class OrganizatorProslava : Window
    {
        public Proslava Proslava{get; set;}
        public Zadatak SelektovanZadatak { get; set; }
        public OrganizacijaProslavaWindow opw { get; set; }
        public OrganizatorProslava(OrganizacijaProslavaWindow parent, Proslava p)
        {
            this.opw = parent;
            this.Proslava = p;
            InitializeComponent();
        }

        public void Dodaj_Zadatke()
        {

        }
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            opw.Show();
            this.Close();
        }
    }
}
