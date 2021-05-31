using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    class Ponuda
    {

        List<string> Slike { get; set; }
        string Opis { get; set; }
        int Cena { get; set; }

        Organizator Organizator { get; set; }

        int Id { get; set; }

    }
}
