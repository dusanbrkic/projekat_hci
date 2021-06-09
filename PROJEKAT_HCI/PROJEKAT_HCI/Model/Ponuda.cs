using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public class Ponuda : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _slika;
        private int _cena;
        private string _opis;
        private Klijent _klijent;
        [Key]
        public int Id { get; set; }
        public String Slika { get { return _slika; } set { _slika = value; OnPropertyChanged("Naziv"); } }
        public string Opis { get { return _opis; } set { _opis = value; OnPropertyChanged("Naziv"); } }
        public int Cena { get { return _cena; } set { _cena = value; OnPropertyChanged("Naziv"); } }
        public virtual Saradnik Saradnik { get; set; }
        public virtual Klijent  Klijent { get { return _klijent; } set { _klijent = value; OnPropertyChanged("Naziv"); } }

    }
}
