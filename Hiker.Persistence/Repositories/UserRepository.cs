using System;
using System.Linq;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hiker.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> GetAsync(Func<User, bool> predicate)
        {
            return _dbContext.Users.SingleOrDefaultAsync(x => predicate.Invoke(x));
        }

        public Task<User> GetByFacebookIdAsync(string facebookId)
        {
            return _dbContext.Users.SingleOrDefaultAsync(user => user.FacebookId == facebookId);
        }

        public async Task<Guid> AddAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }
    }
}