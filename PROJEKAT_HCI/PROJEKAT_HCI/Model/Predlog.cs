using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    class Predlog
    {
        string Opis { get; set; }
        Boolean Prihvacen { get; set; }

        List<Zadatak> Zadaci { get; set; }

        int Id { get; set; }
    }
}
