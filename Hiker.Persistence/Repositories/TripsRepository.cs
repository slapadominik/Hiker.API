using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;

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

        public Task<IEnumerable<Trip>> GetByPredicateAsync(Func<Trip, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}