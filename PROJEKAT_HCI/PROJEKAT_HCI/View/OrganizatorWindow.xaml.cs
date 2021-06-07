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

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for OrganizatorWindow.xaml
    /// </summary>
    partial class OrganizatorWindow : Window
    {
        public MainWindow mw { get; set; }
        public Organizator Organizator { get; set; }

        public OrganizatorWindow()
        {
            InitializeComponent();
        }

        private void Odj_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mw.Show();
            
        }

        private void Saradnici_Btn_Click(object sender, RoutedEventArgs e)
        {
            OrganizatorSaradnici os = new OrganizatorSaradnici();
            os.ow = this;
            this.Hide();
            os.Show();
        }

        private void Obav_Btn_Click(object sender, RoutedEventArgs e) {
            ObavestenjaWindow ow = new ObavestenjaWindow(Organizator, this);
            ow.Show();
            this.Hide();
            
        }

        private void Orgp_Btn_Click(object sender, RoutedEventArgs e)
        {
            OrganizacijaProslavaWindow opw = new OrganizacijaProslavaWindow(Organizator, this);
            this.Hide();
            opw.Show();
        }
    }
}
