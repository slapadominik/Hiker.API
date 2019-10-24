using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hiker.Persistence.Repositories
{
    public class TripsRepository : ITripsRepository
    {
        private AppDbContext _dbContext;

        public TripsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AddAsync(Trip trip)
        {
            _dbContext.Trips.AddAsync(trip);
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Trip> GetByPredicate(Func<Trip, bool> predicate)
        {
            return _dbContext.Trips.Where(predicate);
        }
    }
}