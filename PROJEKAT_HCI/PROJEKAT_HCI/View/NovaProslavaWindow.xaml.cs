using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToastNotifications.Messages;

namespace PROJEKAT_HCI.View
{
    /// <summary>
    /// Interaction logic for NovaProslavaWindow.xaml
    /// </summary>
    public partial class NovaProslavaWindow : Window
    {
        public NovaProslavaWindow()
        {

            InitializeComponent();
        }
        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow kw = new KlijentWindow();
            kw.Show();
            this.Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public class FutureDateValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                DateTime time;
                if (!DateTime.TryParse((value ?? "").ToString(),
                    CultureInfo.CurrentCulture,
                    DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                    out time)) return new ValidationResult(false, "Invalid date");

                return time.Date <= DateTime.Now.Date
                    ? new ValidationResult(false, "Future date required")
                    : ValidationResult.ValidResult;
            }

        }

        private void PotvrdiZahtevBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NazivProslave.Text.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Niste uneli naziv proslave!");
                return;
            }
            if (OpisProslave.Text.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Niste uneli opis proslave!");
                return;
            }
            if (DatumProslave.SelectedDate == null)
            {
                MainWindow.notifier.ShowWarning("Niste uneli datum proslave!");
                return;
            }
            if (Mesto.Text.Equals(""))
            {
                MainWindow.notifier.ShowWarning("Niste uneli opis proslave!");
                return;
            }
            if (BrojGostiju.Text.Equals("") || (Int32.Parse(BrojGostiju.Text) == 0))
            {
                MainWindow.notifier.ShowWarning("Niste uneli broj gostiju!");
                return;
            }
        }
    }
}
