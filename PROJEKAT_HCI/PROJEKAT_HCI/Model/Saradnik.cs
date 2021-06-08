using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public enum TipSaradnika { RESTORAN, POSLASTICARNICA}
    public class Saradnik
    {
        [Key]
        public int Id { get; set; }
        public List<string> Slike { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Lokacija { get; set; }
        public List<Ponuda> Ponude { get; set; }
        public TipSaradnika TipSaradnika { get; set; }
        
    }
}
