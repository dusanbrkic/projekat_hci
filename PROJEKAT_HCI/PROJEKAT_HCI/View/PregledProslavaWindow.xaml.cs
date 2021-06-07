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

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for PregledProslavaWindow.xaml
    /// </summary>
    public partial class PregledProslavaWindow : Window
    {
        private Klijent klijent { get; set; }
        public class Dugme : Button
        {
            public Proslava Proslava { get; set; }
        }
        public PregledProslavaWindow(Klijent k)
        {
            InitializeComponent();
            this.klijent = k;
            using (var db = new ProjectDatabase())
            {
                //var proslave = (from p in db.Proslave where p.Klijent.Id == klijent.Id select p);
                foreach (Proslava p in (from p in db.Proslave where p.Klijent.Id == klijent.Id select p).ToList())
                {
                    Dugme b = new Dugme();
                    b.Proslava = p;
                    b.Width = 200;
                    b.Height = 140;
                    b.Margin = new Thickness(20);
                    b.Content = p.Naziv;
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

        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow();
            kw.Show();
            this.Close();
        }

    }
}
