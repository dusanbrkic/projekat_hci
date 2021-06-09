﻿using PROJEKAT_HCI.Database;
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
    /// Interaction logic for DodavanjeOrganizatoraWindow.xaml
    /// </summary>
    public partial class DodavanjeOrganizatoraWindow : Window
    {
        public DodavanjeOrganizatoraWindow()
        {
            InitializeComponent();
        }

        private Organizator _organizator = null;
        public Organizator Ret { get { return _organizator; } set { _organizator = value; } }

        private void odustao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "" || ime.Text == "" || prezime.Text == "" || brojTelefona.Text == "")
            {
                Console.WriteLine("Greska");
                return;
            }


            if (againPassword.Password != password.Password)
                return;

            using (var db = new ProjectDatabase())
            {

                foreach (Organizator org in db.Organizatori)
                {
                    if (username.Text == org.Username)//vec postoji korisnik sa istim usernamemom
                        return;

                }

                Organizator k = new Organizator { Id = db.Klijenti.Count(), Ime = ime.Text, Prezime = prezime.Text, BrojTelefona = brojTelefona.Text, Email = email.Text, Password = password.Password, Username = username.Text };

                Ret = k;

                db.Organizatori.Add(k);
                db.SaveChanges();
            }

         
            
            this.Close();

        }
    }
}
