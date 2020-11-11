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
            : base(dbContextOptions) {
            this.ChangeTracker.LazyLoadingEnabled = false;
            //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
        }

        /// <summary>
        /// List of novads in our in-memory databse.
        /// </summary>
        public DbSet<Novads> NovadsList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Let's set primary key.
            modelBuilder.Entity<Novads>()
                .HasKey(x => x.Id);
        }
    }
}
