using PROJEKAT_HCI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKAT_HCI.MENAGER
{
    class ManagerFactory : DbContext
    {
        public DbSet<Klijent> klijenti { get; set; }
        public DbSet<Organizator> organizatori { get; set; }
        public DbSet<Admin> admini { get; set; }

        public DbSet<Saradnik> saradnici { get; set; }

    }
}
