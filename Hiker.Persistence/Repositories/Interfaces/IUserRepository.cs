using System;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;

namespace Hiker.Persistence.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Func<User, bool> predicate);
        Task<User> GetByFacebookIdAsync(string id);
        Task<Guid> AddAsync(User user);
    }
}