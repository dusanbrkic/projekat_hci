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
using System.Drawing;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;

namespace PROJEKAT_HCI.View
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            OrganizatoriTable.Visibility = Visibility.Visible;
            KlijentiTable.Visibility = Visibility.Hidden;
            SaradniciTable.Visibility = Visibility.Hidden;
            OrganizatoriBtn.Background =  new SolidColorBrush(Color.FromRgb(203, 159, 237));
            DodavanjeKlijentaBtn.IsEnabled = false;
            DodavanjeKlijentaBtn.Visibility = Visibility.Hidden;
            DodavanjeSaradnikaBtn.IsEnabled = false;
            DodavanjeSaradnikaBtn.Visibility = Visibility.Hidden;
        }

        private void OrganizatoriBtn_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeOrganizatoraBtn.IsEnabled = true;
            DodavanjeOrganizatoraBtn.Visibility = Visibility.Visible;
            DodavanjeKlijentaBtn.IsEnabled = false;
            DodavanjeKlijentaBtn.Visibility = Visibility.Hidden;
            DodavanjeSaradnikaBtn.IsEnabled = false;
            DodavanjeSaradnikaBtn.Visibility = Visibility.Hidden;

            Button btn = sender as Button;
            btn.Background = new SolidColorBrush(Color.FromRgb(203, 159, 237));
            SaradniciBtn.Background = Brushes.Purple;
            KlijentiBtn.Background = Brushes.Purple;
            OrganizatoriTable.Visibility = Visibility.Visible;
            KlijentiTable.Visibility = Visibility.Hidden;
            SaradniciTable.Visibility = Visibility.Hidden;
            
        }

        private void KlijentiBtn_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeKlijentaBtn.IsEnabled = true;
            DodavanjeKlijentaBtn.Visibility = Visibility.Visible;
            DodavanjeOrganizatoraBtn.IsEnabled = false;
            DodavanjeOrganizatoraBtn.Visibility = Visibility.Hidden;
            DodavanjeSaradnikaBtn.IsEnabled = false;
            DodavanjeSaradnikaBtn.Visibility = Visibility.Hidden;
            Button btn = sender as Button;
            btn.Background = new SolidColorBrush(Color.FromRgb(203, 159, 237));
            SaradniciBtn.Background = Brushes.Purple;
            OrganizatoriBtn.Background = Brushes.Purple;
            OrganizatoriTable.Visibility = Visibility.Hidden;
            KlijentiTable.Visibility = Visibility.Visible;
            SaradniciTable.Visibility = Visibility.Hidden;
        }

        private void SaradniciBtn_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeKlijentaBtn.IsEnabled = false;
            DodavanjeKlijentaBtn.Visibility = Visibility.Hidden;
            DodavanjeOrganizatoraBtn.IsEnabled = false;
            DodavanjeOrganizatoraBtn.Visibility = Visibility.Hidden;
            DodavanjeSaradnikaBtn.IsEnabled = true;
            DodavanjeSaradnikaBtn.Visibility = Visibility.Visible;
            Button btn = sender as Button;
            btn.Background = new SolidColorBrush(Color.FromRgb(203, 159, 237));
            OrganizatoriBtn.Background = Brushes.Purple;
            KlijentiBtn.Background = Brushes.Purple;
            OrganizatoriTable.Visibility = Visibility.Hidden;
            KlijentiTable.Visibility = Visibility.Hidden;
            SaradniciTable.Visibility = Visibility.Visible;
        }

        private void OdjavaBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();

        }

        private void DodavanjeSaradnikaBtn_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeSaradnikaWindow ds = new DodavanjeSaradnikaWindow();
            ds.ShowDialog();

        }

        private void DodavanjeOrganizatoraBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DodavanjeKlijentaBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
