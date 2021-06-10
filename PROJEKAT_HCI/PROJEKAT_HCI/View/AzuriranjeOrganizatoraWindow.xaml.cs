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
using ToastNotifications.Messages;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for AzuriranjeOrganizatoraWindow.xaml
    /// </summary>
    public partial class AzuriranjeOrganizatoraWindow : Window
    {
        Organizator k;
        public AzuriranjeOrganizatoraWindow(Organizator _k)
        {
            InitializeComponent();
            k = _k;
            ime.Text = k.Ime;
            prezime.Text = k.Prezime;
            brojTelefona.Text = k.BrojTelefona;
            email.Text = k.Email;
            username.Text = k.Username;
        }

        private void odustao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Azuriraj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ProjectDatabase())
            {
                var k2 = db.Organizatori.First(a => a.Id == k.Id);
                
                k2.Ime = ime.Text;
                k2.Prezime = prezime.Text;
                k2.BrojTelefona = brojTelefona.Text;
                k2.Email = email.Text;
                k2.Username = username.Text;
                db.SaveChanges();

            }

            MainWindow.notifier.ShowInformation("Organizator je uspješno ažuriran.");
            
            this.Close();
        }
    }
}
