using System;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Task DeleteAsync(TripParticipant tripParticipant)
        {
            _dbContext.TripParticipants.Remove(tripParticipant);
            return _dbContext.SaveChangesAsync();
        }

        public Task<TripParticipant> GetAsync(Guid userId, int tripId)
        {
            return _dbContext.TripParticipants.SingleOrDefaultAsync(x => x.TripId == tripId && x.UserId == userId);
        }
    }
}