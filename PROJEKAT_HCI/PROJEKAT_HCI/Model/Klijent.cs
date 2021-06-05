﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    class Klijent : Korisnik
    {
        [Key]
        public int Id { get; set; }

        public List<Proslava> Proslave { set; get; }
    }
}
