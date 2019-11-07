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
        private const int MountainType = 1;
        private const int RockType = 2;

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
                .Include(x => x.Trip)
                .Where(x => x.RockId == rockId && x.Trip.DateFrom > dateFrom);
        }
    }
}