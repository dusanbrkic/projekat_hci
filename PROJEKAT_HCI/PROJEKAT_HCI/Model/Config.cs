using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Model
{
    public class Config
    {
        [Key]
        public int Id { get; set; }
        public bool firstRun{get; set;}
    }
}
