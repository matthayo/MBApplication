using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MBApplication.Data{

    public class MBAppContext : DbContext
    {

        public MBAppContext(DbContextOptions<MBAppContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Premise> Premises { get; set; }
    }
}