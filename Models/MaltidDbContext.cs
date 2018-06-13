using Microsoft.EntityFrameworkCore;
using MaltidRapporter.Models;

namespace MaltidRapporter.Models
{
    public class MaltidDbContext : DbContext
    {

        public MaltidDbContext(DbContextOptions<MaltidDbContext> options) : base(options)
        {
        }

        public DbSet<MaltidReport> MaltidReport { get; set; }
        public DbSet<MaltidPortionstyp> MaltidPortionstyp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaltidReport>().ToTable("MaltidRapporter");
            modelBuilder.Entity<MaltidPortionstyp>().ToTable("MaltidPortionstyper");
            modelBuilder.Entity<MaltidVerksamhet>().ToTable("MaltidVerksamheter");
        }

        public DbSet<MaltidRapporter.Models.MaltidVerksamhet> MaltidVerksamhet { get; set; }

    }
}
