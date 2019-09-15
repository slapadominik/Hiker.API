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

        }
    }
}