using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public class Klijent : Korisnik
    {
        [Key]
        public int Id { get; set; }

        public List<Proslava> Proslave { set; get; }

        public List<ZahtevProslave> Zahtevi { set; get; }

        public String welcomeMessage()
        {
            return ("Dobrodosli, " + Ime + " " + Prezime);
        }
    }
}
