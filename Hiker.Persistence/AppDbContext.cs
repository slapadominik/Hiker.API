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
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}