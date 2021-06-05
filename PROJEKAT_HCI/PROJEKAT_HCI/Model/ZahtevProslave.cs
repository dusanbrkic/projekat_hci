using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    class ZahtevProslave
    {
        [ForeignKey("Proslava")]
        public int Id { get; set; }
        public bool Prihvacena { get; set; }

        public virtual Proslava Proslava { get; set; }
    }
}
