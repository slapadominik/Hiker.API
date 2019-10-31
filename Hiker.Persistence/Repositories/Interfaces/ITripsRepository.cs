using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;

namespace Hiker.Persistence.Repositories.Interfaces
{
    public interface ITripsRepository
    {
        int Add(Trip trip);
        Task<Trip> GetByIdAsync(int tripId);
        IEnumerable<Trip> GetByPredicate(Func<Trip, bool> predicate);
    }
}