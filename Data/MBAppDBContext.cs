using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MBApplication.Data
{

    public class MBAppDBContext : DbContext
    {
        public MBAppDBContext(DbContextOptions<MBAppDBContext> options) : base(options) { }

        //DataSets
        public DbSet<Family> Families { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}