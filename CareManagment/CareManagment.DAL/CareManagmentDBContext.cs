using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DAL
{
    class CareManagmentDbContext : DbContext
    {
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
    }
}
