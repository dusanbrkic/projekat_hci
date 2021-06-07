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
using PROJEKAT_HCI.View;


namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for OrganizatorSaradnici.xaml
    /// </summary>
    public partial class OrganizatorSaradnici : Window
    {
        public class Dugme : Button
        {
            public  Saradnik Saradnik{ get; set; }
        }
        public OrganizatorWindow ow {get; set;}
        public OrganizatorSaradnici()
        {
            InitializeComponent();

            using (var db = new ProjectDatabase())
            {
                 foreach(Saradnik s in db.Saradnici.ToList())
                 {
                    Dugme b = new Dugme();
                    b.Saradnik = s;
                    b.Width = 200;
                    b.Height = 140;
                    b.Margin = new Thickness(20);
                    b.Content = s.Naziv;
                    wrapper.Children.Add(b);
                    b.Click += new RoutedEventHandler(Saradnik_Btn_Click) ;
                 }
            }
            
        }

        private void Saradnik_Btn_Click(object sender, RoutedEventArgs e)
        {
            Dugme b = (Dugme)sender;
            Console.WriteLine(b.Saradnik.Opis);
            
            OrganizatorSaradnikWindow osw = new OrganizatorSaradnikWindow(b.Saradnik, this);
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
