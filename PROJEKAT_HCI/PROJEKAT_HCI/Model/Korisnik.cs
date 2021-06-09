using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public class Korisnik : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _ime;
        private string _prezime;
        private string _email;
        private string _username;
        private string _brojTelefona;

        


        public string Ime { get { return _ime; } set { _ime = value; OnPropertyChanged("Ime"); } }
        public string Prezime { get { return _prezime; } set { _prezime = value; OnPropertyChanged("Prezime"); } }
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }
        public string Password { get; set; }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }
        public string BrojTelefona
        {
            get { return _brojTelefona; }
            set { _brojTelefona = value; OnPropertyChanged("BrojTelefona"); }
        }

    }
}
