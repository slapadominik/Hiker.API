using System;
using System.Collections.Generic;
using System.Linq;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hiker.Persistence.Repositories
{
    public class TripDestinationRepository : ITripDestinationRepository
    {
        private readonly AppDbContext _appDbContext;

        public TripDestinationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TripDestination> GetUpcomingByMountainId(int mountainId, DateTime dateFrom)
        {
            return _appDbContext.TripDestinations
                .Include(x => x.Trip)
                .Where(x => x.MountainId == mountainId && x.Trip.DateFrom > dateFrom);
        }

        public IEnumerable<TripDestination> GetUpcomingByRockId(int rockId, DateTime dateFrom)
        {
            return _appDbContext.TripDestinations
                .Include(x => x.Rock)
                .Where(x => x.RockId == rockId && x.Trip.DateFrom > dateFrom);
        }

        public void Delete(int tripId)
        {
            var destinations = _appDbContext.TripDestinations.Where(x => x.TripId == tripId);
            _appDbContext.TripDestinations.RemoveRange(destinations);
            _appDbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<TripDestination> tripDestinations)
        {
            _appDbContext.TripDestinations.AddRange(tripDestinations);
            _appDbContext.SaveChanges();
        }
    }
}