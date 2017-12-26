
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MBApplication.Data
{
    public class MBAppContextFactory : IDesignTimeDbContextFactory<MBAppContext>
    {
        public MBAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MBAppContext>();
            optionsBuilder.UseMySQL("Data Source = mbapp.db");

            return new MBAppContext(optionsBuilder.Options);
        } 
    } 
    
} 