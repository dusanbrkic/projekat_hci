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
using PROJEKAT_HCI.View;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for OrganizatorSaradnikWindow.xaml
    /// </summary>
    public partial class OrganizatorSaradnikWindow : Window
    {
        public Saradnik Saradnik { get; set; }
        public OrganizatorSaradnici os { get; set; }
        public OrganizatorSaradnikWindow(Saradnik s, OrganizatorSaradnici ost)
        {
            this.Saradnik = s;
            this.os = ost;
            InitializeComponent();
            this.Title = Saradnik.Naziv;
            Opis.Content = Saradnik.Opis;
            Lokacija.Content = Saradnik.Lokacija;
        }

        private void Nazad_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            os.Show();
        }
        private void NovaPonuda_Btn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
