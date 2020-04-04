using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Structs;


namespace Hiker.Persistence.Repositories.Interfaces
{
    public interface IMountainsRepository
    {
        Task<List<Mountain>> GetAllAsync();
        Task<Mountain> GetByIdAsync(int mountainId);
        Task<Guid?> GetMountainThumbnailIdAsync(int mountainId);
        bool Exists(int mountainId);
        Task<List<Mountain>> GetMountainsWithUpcomingTripsByRadius(LatLongRadius latLong, int radiusKilometers);
    }
}