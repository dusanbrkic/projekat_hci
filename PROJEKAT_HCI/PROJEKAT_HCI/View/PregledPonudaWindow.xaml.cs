using PROJEKAT_HCI.Database;
using PROJEKAT_HCI.Model;
using PROJEKAT_HCI.View;
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

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for PregledPonudaWindow.xaml
    /// </summary>
    public partial class PregledPonudaWindow : Window
    {
        private Klijent klijent { get; set; }
        public class Dugme : Button
        {
            public Ponuda Ponuda { get; set; }
        }
        public PregledPonudaWindow(Klijent k)
        {
            InitializeComponent();
            this.klijent = k;
            using (var db = new ProjectDatabase())
            {
                //var proslave = (from p in db.Proslave where p.Klijent.Id == klijent.Id select p);
                foreach(Ponuda p in (from p in db.Ponude where p.Klijent.Id == klijent.Id select p).ToList())
                {
                    Dugme b = new Dugme();
                    b.Ponuda = p;
                    b.Width = 200;
                    b.Height = 140;
                    b.Margin = new Thickness(20);
                    b.Content = p.Opis;
                    wrapper.Children.Add(b);
                    b.Click += new RoutedEventHandler(Proslava_Btn_Click);
                }
/*                foreach (Proslava p in db.Proslave)
                {

                }*/
            }
        }

        private void Proslava_Btn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PotvrdiZahtevBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Ponuda_Click(object sender, RoutedEventArgs e)
        {
            PregledPonude pp = new PregledPonude();
            pp.Show();
            this.Close();
        }
        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow(klijent);
            kw.Show();
            this.Close();
        }
    }
}
