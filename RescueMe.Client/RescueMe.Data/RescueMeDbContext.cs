using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RescueMe.Common;

namespace RescueMe.Data
{
    public class RescueMeDbContext : DbContext
    {
        public DbSet<Emergency> Emergencies { get; set; } 
    
        public RescueMeDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Constants.DatabaseFilename);
        }
}
}
