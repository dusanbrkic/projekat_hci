using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    enum TipSaradnika { RESTORAN, POSLASTICARNICA}
    class Saradnik
    {
        public List<string> Slike { get; set; }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public string Lokacija { get; set; }
        
    }
}
