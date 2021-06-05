using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public class Obavestenje
    {
        [Key]
        public int Id { get; set; }
        public bool Procitano { get; set; }
        public string Sadrzaj { get; set; }
        public virtual PredlogProslave PredlogProslave { get; set; }
    }
}
