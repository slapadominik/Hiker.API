using System;
using System.Collections.Generic;
using Hiker.Persistence.DAO;

namespace Hiker.Persistence.Repositories.Interfaces
{
    public interface ITripDestinationRepository
    {
        IEnumerable<TripDestination> GetUpcomingByMountainId(int mountainId, DateTime dateFrom);
        IEnumerable<TripDestination> GetUpcomingByRockId(int rockId, DateTime dateFrom);
        void Delete(int tripId);
        void AddRange(IEnumerable<TripDestination> tripDestinations);
    }
}