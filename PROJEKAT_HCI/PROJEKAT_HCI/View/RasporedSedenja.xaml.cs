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
    /// Interaction logic for RasporedSedenja.xaml
    /// </summary>
    public partial class RasporedSedenja : Window
    {
        public RasporedSedenja()
        {
            InitializeComponent();
        }

        class ExampleItemViewModel
        {
            public bool CanAcceptChildren { get; set; }

            public int size { get; set; }
            public ObservableCollection<ExampleItemViewModel> Children { get; private set; }
        }
    }
}
