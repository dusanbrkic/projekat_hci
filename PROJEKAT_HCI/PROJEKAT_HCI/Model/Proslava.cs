using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    enum StatusProslave { CEKA_SE_ORGANIZATOR, U_ORGANIZACIJI, ORGANIZOVANO,  OTKAZANA}
    class Proslava
    {
        int Id { get; set; }
        int Organizator { get; set; }
        int Klijent { get; set; }
        string Opis { get; set; }
        string Naziv { get; set; }
        StatusProslave StatusProslave { get; set; }

    }
}
