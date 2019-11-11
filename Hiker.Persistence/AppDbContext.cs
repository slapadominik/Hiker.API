using Hiker.Persistence.DAO;
using Microsoft.EntityFrameworkCore;

namespace Hiker.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Mountain> Mountains { get; set; }
        public DbSet<MountainTrail> MountainTrails { get; set; }
        public DbSet<MountainTrailColor> MountainTrailColors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripDestination> TripDestinations { get; set; }
        public DbSet<TripDestinationType> TripDestinationTypes { get; set; }
        public DbSet<MountainImage> MountainImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TripParticipant> TripParticipants { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MountainImage>()
                .HasKey(t => new {t.ImageId, t.MountainId});

            modelBuilder.Entity<TripParticipant>()
                .HasKey(t => new {t.TripId, t.UserId});
            modelBuilder.Entity<TripParticipant>()
                .HasOne(x => x.User)
                .WithMany(u => u.TripParticipants)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<TripParticipant>()
                .HasOne(x => x.Trip)
                .WithMany(t => t.TripParticipants)
                .HasForeignKey(x => x.TripId);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TripDestinationType>()
                .HasData(new TripDestinationType[]
                {
                    new TripDestinationType { Id = 1, Name = "Mountain" },
                    new TripDestinationType { Id = 2, Name = "Rock"}
                });


            modelBuilder.Entity<MountainTrailColor>()
                .HasData(new MountainTrailColor[]
                {
                    new MountainTrailColor { Id = 1, ColorName = "red" },
                    new MountainTrailColor { Id = 2, ColorName = "blue"},
                    new MountainTrailColor { Id = 3, ColorName = "yellow"},
                    new MountainTrailColor { Id = 4, ColorName = "black"},
                    new MountainTrailColor { Id = 5, ColorName = "green"},
                });
        }
    }
}