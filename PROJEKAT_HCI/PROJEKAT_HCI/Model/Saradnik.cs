using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public enum TipSaradnika { RESTORAN, POSLASTICARNICA, MUZIKA, DEKORACIJE , OSTALO}
    public class Saradnik : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _naziv;
        private string _opis;
        private string _lokacija;
        private TipSaradnika _tip;
        [Key]
        public int Id { get; set; }
        public List<string> Slike { get ; set; }
        public string Naziv { get { return _naziv; } set { _naziv = value; OnPropertyChanged("Naziv"); } }
        public string Opis { get { return _opis; } set { _opis = value; OnPropertyChanged("Opis"); } }
        public string Lokacija { get { return _lokacija; } set { _lokacija = value; OnPropertyChanged("Lokacija"); } }
        public List<Ponuda> Ponude { get; set; }
        public TipSaradnika TipSaradnika { get { return _tip; } set { _tip = value; OnPropertyChanged("TipSaradnika"); } }


       public override string  ToString() {

            return _naziv;
        }
    }
}
