using ExcitelLead.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExcitelLead.Infrastructure.Persistence.EF
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public virtual DbSet<Lead> Lead { get; set; }

        public virtual DbSet<SubArea> SubAreas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Scans a given assembly for all types that implement IEntityTypeConfiguration, and registers each one automatically
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
