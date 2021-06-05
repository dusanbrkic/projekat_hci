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
    /// Interaction logic for OrganizatorSaradnici.xaml
    /// </summary>
    public partial class OrganizatorSaradnici : Window
    {
        public OrganizatorWindow ow {get; set;}
        public OrganizatorSaradnici()
        {
            InitializeComponent();
            
            for(int i = 0; i < 9; i++)
            {
                Button b = new Button();
                b.Width = 200;
                b.Height = 140;
                b.Margin = new Thickness(20);
                b.Content = i + "ti saradnik";
                wrapper.Children.Add(b);
            }
        }

    }
}
