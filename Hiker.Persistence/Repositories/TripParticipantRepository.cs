using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;

namespace Hiker.Persistence.Repositories
{
    public class TripParticipantRepository : ITripParticipantRepository
    {
        private readonly AppDbContext _dbContext;

        public TripParticipantRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(TripParticipant tripParticipant)
        {
            _dbContext.TripParticipants.AddAsync(tripParticipant);
            return _dbContext.SaveChangesAsync();
        }
    }
}