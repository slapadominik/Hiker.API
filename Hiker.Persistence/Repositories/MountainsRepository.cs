using System;
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
            return _appDbContext.Mountains
                .Include(x => x.Location)
                .Include(x => x.MountainTrail)
                .Include(x => x.TripDestinations).ThenInclude(x => x.Trip)
                .ToListAsync();
        }

        public Task<Mountain> GetByIdAsync(int mountainId)
        {
            return _appDbContext.Mountains
                .Include(x => x.Location)
                .Include(x => x.MountainImages)
                .Include(x => x.MountainTrail).ThenInclude(x => x.Color)
                .SingleOrDefaultAsync(x => x.Id == mountainId);
        }

        public async Task<Guid?> GetMountainThumbnailIdAsync(int mountainId)
        {
            var mountain = await _appDbContext.Mountains.SingleOrDefaultAsync(x => x.Id == mountainId);
            return mountain?.ThumbnailId;
        }

        public bool Exists(int mountainId)
        {
            return _appDbContext.Mountains.Any(x => x.Id == mountainId);
        }
    }
}