using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MBApplication.Data{

    public class AppContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = MBAppData; Trusted_Connection = True");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Premise> Premises { get; set; }
    }
}