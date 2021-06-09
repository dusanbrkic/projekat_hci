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
    /// Interaction logic for DodavanjeSaradnikaWindow.xaml
    /// </summary>
    public partial class DodavanjeSaradnikaWindow : Window
    {

        private Saradnik _saradnik = null;
        public Saradnik Ret { get { return _saradnik; } set { _saradnik = value; } }

        public DodavanjeSaradnikaWindow()
        {
            InitializeComponent();

            foreach (TipSaradnika ss in Enum.GetValues(typeof(TipSaradnika)))
            {

                Tip.Items.Add(ss.ToString());


            }
        }

        private void odustao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void Dodaj_saradnika_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ProjectDatabase())
            {

                foreach (Saradnik sar in db.Saradnici)
                {
                    if (Naziv.Text == sar.Naziv)//vec postoji korisnik sa istim usernamemom
                        return;

                } 
                Enum.TryParse(Tip.Text, out TipSaradnika t); 
                Saradnik s = new Saradnik { Naziv = Naziv.Text, Opis = Opis.Text, Lokacija = Lokacija.Text, TipSaradnika =t };

               

                Ret = s;
                db.Saradnici.Add(s);
                db.SaveChanges();
            }
        }
    }
}
