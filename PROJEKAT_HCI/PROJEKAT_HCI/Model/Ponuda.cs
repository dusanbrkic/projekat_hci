﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    class Ponuda
    {
        [ForeignKey("Zadatak")]
        public int Id { get; set; }
        public List<string> Slike { get; set; }
        public string Opis { get; set; }
        public int Cena { get; set; }
        public int ZadatakId { get; set; }
        public virtual Zadatak Zadatak { get; set; }
        public virtual Saradnik Saradnik { get; set; }

    }
}
