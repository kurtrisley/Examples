using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GolfClubs.Models
{
    public class GolfClubsContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }

        public DbSet<ClubType> ClubTypes { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Club>()
                .HasMany(m => m.Categories)
                .WithMany(c => c.Clubs)
                .Map(m =>
                {
                    m.ToTable("ClubCategory");
                    m.MapLeftKey("ClubId");
                    m.MapRightKey("CategoryId");
                });

        }
    }
}
