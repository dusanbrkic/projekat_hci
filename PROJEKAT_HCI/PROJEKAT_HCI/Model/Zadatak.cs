using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    enum Status_Zadatka { ZA_URADITI, U_OBRADI, ZA_POSLATI, POSLATI, PRIHVACENO, ZA_IZMENU, ODBIJENO }
    class Zadatak
    {
        [Key]
        public int Id { get; set; }
        public string Opis { get; set; }
        public Status_Zadatka Status { get; set; }
        public string KomentarKlijenta { get; set; }
        public virtual Ponuda Ponuda { get; set; }
        public virtual PredlogProslave PredlogProslave { get; set; }

    }
}
