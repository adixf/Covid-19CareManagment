using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DAL
{
    class CareManagmentDb : DbContext
    {
        public CareManagmentDb() : base("CareManagmentDb2020")
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Package>()
           .HasOptional<Recipient>(s => s.Recipient)
           .WithMany()
           .WillCascadeOnDelete(false);
            modelBuilder.Entity<Distribution>()
          .HasOptional<User>(s => s.Volunteer)
          .WithMany()
          .WillCascadeOnDelete(false);
            modelBuilder.Entity<Distribution>()
          .HasOptional<User>(s => s.Admin)
          .WithMany()
          .WillCascadeOnDelete(false);
            modelBuilder.Entity<Package>().Property(p => p.RecipientId).IsOptional();
            modelBuilder.Entity<Distribution>().Property(p => p.AdminId).IsOptional();
            modelBuilder.Entity<Distribution>().Property(p => p.VolunteerId).IsOptional();

        }

    }
}
