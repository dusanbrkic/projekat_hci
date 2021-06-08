using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public class PredlogProslave
    {
        [ForeignKey("Proslava")]
        public int Id { get; set; }
        public string Opis { get; set; }
        public string KomentarKlijenta { get; set; }
        public bool Prihvacen { get; set; }

        public virtual Proslava Proslava { get; set; }
        public virtual List<Obavestenje> Obavestenja { get; set; }
        public virtual List<Zadatak> Zadaci { get; set; }
    }
}
