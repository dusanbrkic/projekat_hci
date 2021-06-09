using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using PROJEKAT_HCI.Model;
using PROJEKAT_HCI.Database;
using System.ComponentModel;
namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for RasporedSedenja.xaml
    /// </summary>
    public partial class RasporedSedenja : Window
    {
        public RasporedSedenja()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "CSV Files(*.CSV;)|*.CSV;|All files (*.*)|*.*";
            //bool? okdia = ofd.ShowDialog();
            string sFileName = ofd.FileName;         
            using (var reader = new StreamReader(sFileName))
            {
                List<String> gosti = new List<String>();
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] temp = line.Split(',');

                    gosti.Add(temp[0] + " " + temp[1]);
                }
            }
            //Nullable<bool> okdia = ofd.ShowDialog();
        }
    }
}
