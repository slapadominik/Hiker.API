using System.Threading.Tasks;
using Hiker.Persistence.DAO;

namespace Hiker.Persistence.Repositories.Interfaces
{
    public interface ITripParticipantRepository
    {
        Task AddAsync(TripParticipant tripParticipant);
    }
}