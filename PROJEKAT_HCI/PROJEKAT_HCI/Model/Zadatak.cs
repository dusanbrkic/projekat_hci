using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    enum Status_Zadatka { ZA_URADITI, U_OBRADI, ZA_POSLATI, POSLATI, PRIHVACENO, ZA_IZMENU, ODBIJENO }
    class Zadatak
    {
        Ponuda Ponuda { get; set; }
        string Opis { get; set; }
        Status_Zadatka Status { get; set; }
        int Id { get; set; }

    }
}
