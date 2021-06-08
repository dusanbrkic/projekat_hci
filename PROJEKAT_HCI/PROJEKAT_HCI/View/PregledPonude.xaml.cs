using PROJEKAT_HCI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PregledPonude.xaml
    /// </summary>
    public partial class PregledPonude : Window
    {
        private Proslava proslava;
        private Klijent klijent;

        public PregledPonude()
        {
            InitializeComponent();

//            this.ponudaTable.Rows.Add("five", "six", "seven", "eight"); 
  //          this.ponudaTable.Rows.Insert(0, "one", "two", "three", "four");
        }
        public ObservableCollection<Ponuda> Ponude
        {
            get;
            set;
        }
        public PregledPonude(Proslava proslava, Klijent klijent)
        {

            this.proslava = proslava;
            this.klijent = klijent;
            InitializeComponent();
            this.DataContext = this;
            OpisProslave.Text = proslava.Opis;
//          foreach (Zadatak z in this.proslava.PredlogProslave.Zadaci)
  //                    {
      //        ponudaTable.Items.Add((z.Ponuda.Saradnik, z.Ponuda.Cena, z.Ponuda.Opis));
    //        }
            List<Ponuda> l = new List<Ponuda>();
            l.Add(new Ponuda { Saradnik = null, Cena = 100, Opis = "ASDADADADA" });
            l.Add(new Ponuda { Saradnik = null, Cena = 100, Opis = "ASDADADADA" });
            l.Add(new Ponuda { Saradnik = null, Cena = 100, Opis = "ASDADADADA" });

            Ponude = new ObservableCollection<Ponuda>(l);

           // View = CollectionViewSource.GetDefaultView(Ponude);


        }
        private StackPanel PostaviOdg()
        {
            Button accept = new Button();
            Button decline = new Button();
            Button comment = new Button();
            accept.Content = "Prihvati";
            decline.Content = "Odustnai";
            comment.Content ="1231";
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            sp.Children.Add(accept);
            sp.Children.Add(decline);
            sp.Children.Add(comment);
            return sp;
        }
        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                    row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }
        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow(klijent);
            kw.Show();
            this.Hide();
        }
    }
}
