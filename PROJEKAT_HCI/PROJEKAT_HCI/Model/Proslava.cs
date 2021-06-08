using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public enum StatusProslave { CEKA_SE_ORGANIZATOR, U_ORGANIZACIJI, ORGANIZOVANO,  OTKAZANA}
    public class Proslava
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string Naziv { get; set; }
        public StatusProslave StatusProslave { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DatumOdrzavanja { get; set; }

        public virtual Organizator Organizator { get; set; }
        public virtual Klijent Klijent { get; set; }
        public virtual PredlogProslave PredlogProslave { get; set; }
        public virtual ZahtevProslave ZahtevProslave { get; set; }
        public int BrojGostiju { get;  set; }
        public double Budzet { get;  set; }
    }
}
