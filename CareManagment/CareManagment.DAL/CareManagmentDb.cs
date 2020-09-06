using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DAL
{
    class CareManagmentDb : DbContext
    {
        public CareManagmentDb():base("CareManagmentDb2020")
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        
    }
}
