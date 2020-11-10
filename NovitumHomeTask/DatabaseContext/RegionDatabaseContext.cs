using Microsoft.EntityFrameworkCore;
using NovitumHomeTask.Model;

namespace EasyCruitChallenge.DatabaseContext
{
    /// <summary>
    /// Database context for regions. Using an in-memory databse.
    /// </summary>
    public class RegionDatabaseContext : DbContext
    {
        public RegionDatabaseContext(
            DbContextOptions<RegionDatabaseContext> dbContextOptions)
            : base(dbContextOptions) { }

        /// <summary>
        /// List of novads in our in-memory databse.
        /// </summary>
        public DbSet<Novads> NovadsList { get; set; }

        /// <summary>
        /// List of pagasts in our in-memory databse.
        /// </summary>
        public DbSet<Pagasts> PagastsList { get; set; }

        /// <summary>
        /// List of polygon1km in our in-memory databse.
        /// </summary>
        public DbSet<Polygon1km> Polygon1kmList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Let's set primary key.
            modelBuilder.Entity<Novads>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Pagasts>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Polygon1km>()
                .HasKey(x => x.Id);
        }
    }
}
