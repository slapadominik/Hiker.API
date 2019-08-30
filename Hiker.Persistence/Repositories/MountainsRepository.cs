using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hiker.Persistence.Repositories
{
    public class MountainsRepository : IMountainsRepository
    {
        private readonly AppDbContext _appDbContext;

        public MountainsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Mountain>> GetAllAsync()
        {
            return _appDbContext.Mountains.Include(x => x.Location).ToListAsync();
        }
    }
}