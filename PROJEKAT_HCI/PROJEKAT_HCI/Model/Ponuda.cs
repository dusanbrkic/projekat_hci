using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public class Ponuda
    {
        [Key]
        public int Id { get; set; }
        public String Slika { get; set; }
        public string Opis { get; set; }
        public int Cena { get; set; }
        public virtual Saradnik Saradnik { get; set; }

    }
}
