using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MBApplication.Data
{

    public class MBAppContext : DbContext
    {
        public MBAppContext(DbContextOptions<MBAppContext> options) : base(options)
        {

        }

        //DataSets
        public DbSet<Family> Families { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Premise> Premises { get; set; }
    }
}