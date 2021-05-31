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
        List<string> Slike { get; set; }
        int Id { get; set; }
        string Naziv { get; set; }
        string Opis { get; set; }

        string Lokacija { get; set; }
        
    }
}
