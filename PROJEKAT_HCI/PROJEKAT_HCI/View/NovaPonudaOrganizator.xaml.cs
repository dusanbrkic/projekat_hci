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
using Microsoft.Win32;
using System.IO;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for NovaPonudaOrganizator.xaml
    /// </summary>
    public partial class NovaPonudaOrganizator : Window
    {

        public OrganizatorSaradnikWindow os { get; set; }

        public Saradnik Saradnik;
        public NovaPonudaOrganizator(OrganizatorSaradnikWindow osw, Saradnik s)
        {
            InitializeComponent();
            this.Saradnik = s;
            this.os = osw;
        }
        private void Nazad_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            os.Show();
        }

        private void Image_Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Image Files(*.JPG;)|*.JPG;|All files (*.*)|*.*";
            Nullable<bool> okdia = ofd.ShowDialog();
            if(okdia == true)
            {
                Random r = new Random();
                String newPath = "../../Res/Images/" + r.Next(10000, 100000) + ".jpg";
                
                File.Copy(ofd.FileName, newPath);
                
                //Image_Btn.Background = new ImageBrush(new BitmapImage(newPath));
                //Console.WriteLine(Directory.GetCurrentDirectory());
            }
        }
    }
}
