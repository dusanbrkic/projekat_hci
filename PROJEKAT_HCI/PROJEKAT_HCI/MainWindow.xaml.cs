﻿using PROJEKAT_HCI.Database;
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
            if (username.Text == "" || password.Text == "")
                return;

            if (username.Text == "admin" && password.Text == "admin")
            {
                AdminWindow a = new AdminWindow();
                a.Show();
                this.Close();
            }
            if (username.Text == "org" && password.Text == "org")
            {
                OrganizatorWindow or = new OrganizatorWindow();
                using (var db = new ProjectDatabase()) {
                    or.Organizator = db.Organizatori.Find(1);
                }

                or.Show();
                or.mw = this;
                this.Hide();
            }
        }
            

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow();
            rw.Show();
            this.Close();
        }
    }
}
