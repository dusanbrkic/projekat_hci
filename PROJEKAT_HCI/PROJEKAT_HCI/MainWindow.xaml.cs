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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToastNotifications.Messages;

namespace PROJEKAT_HCI
{
    
    public partial class MainWindow : Window
    {
        
        Korisnik k = null;

        public MainWindow()
        {
            new DataScript().FillInData();
            InitializeComponent();
        }

        private void Prijava_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "")
                return;

            if (username.Text == "admin" && password.Password == "admin")
            {
                AdminWindow a = new AdminWindow();
                a.Show();
                this.Close();
            }
            if (username.Text == "org" && password.Password == "org")
            {
                OrganizatorWindow or = new OrganizatorWindow();
                using (var db = new ProjectDatabase()) {
                    or.Organizator = db.Organizatori.Find(1);
                }

                or.Show();
                or.mw = this;
                this.Hide();
            }
            if(username.Text == "user" && password.Password == "user")
            {
                KlijentWindow kw = new KlijentWindow();
                kw.Show();
                kw.Mw = this;
                this.Hide();
            }
            using (var db = new ProjectDatabase()) {
                var organizator = (from o in db.Organizatori
                                  where o.Username == username.Text &&
                                  o.Password == password.Password
                                   select o).FirstOrDefault();
                k = (from k in db.Klijenti
                                   where k.Username == username.Text &&
                                   k.Password == password.Password
                                   select k).FirstOrDefault();

                if (organizator != null) {
                    OrganizatorWindow or = new OrganizatorWindow();
                    or.Organizator = organizator;
                    or.Show();
                    or.mw = this;

                  
                        var obavestenja = from obavestenje in db.Obavestenja
                                          where obavestenje.PredlogProslave.Proslava.Organizator.Id == organizator.Id
                                          && obavestenje.Procitano == false
                                          orderby obavestenje.TimeStamp descending
                                          select obavestenje;

                        if (obavestenja != null && obavestenja.Count()!=0)
                            MainWindow.notifier.ShowInformation("Imate " + obavestenja.Count().ToString() + " novih obavestenja!");

                    this.Hide();
                }
                if (k == null)
                {
                    return;
                }
                if (typeof(Klijent).IsInstanceOfType(k))
                {
                    KlijentWindow kw = new KlijentWindow(k as Klijent);
                    kw.Show();
                    kw.Mw = this;
                    this.Hide();
                }


            }
        }
            

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow(this);
            rw.Show();
            this.Hide();
        }
        public static ToastNotifications.Notifier notifier = new ToastNotifications.Notifier(cfg =>
        {
            cfg.PositionProvider = new ToastNotifications.Position.WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: ToastNotifications.Position.Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new ToastNotifications.Lifetime.TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: ToastNotifications.Lifetime.MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
    }
}
