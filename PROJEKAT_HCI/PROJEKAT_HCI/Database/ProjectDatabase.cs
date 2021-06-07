using PROJEKAT_HCI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.Database
{
    public class ProjectDatabase : DbContext
    {
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Organizator> Organizatori { get; set; }
        public DbSet<Admin> Admini { get; set; }
        public DbSet<Saradnik> Saradnici { get; set; }
        public DbSet<Proslava> Proslave { get; set; }
        public DbSet<Obavestenje> Obavestenja { get; set; }
        public DbSet<Ponuda> Ponude { get; set; }
        public DbSet<Config> kofiguracija { get; set; }

    }
}
