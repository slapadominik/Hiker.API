using System;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;

namespace Hiker.Persistence.Repositories.Interfaces
{
    public interface ITripParticipantRepository
    {
        Task AddAsync(TripParticipant tripParticipant);

        Task DeleteAsync(TripParticipant tripParticipant);

        Task<TripParticipant> GetAsync(Guid userId, int tripId);
    }
}