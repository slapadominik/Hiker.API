using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Query;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters.Interfaces
{
    public interface ITripResourceConverter
    {
        TripQueryResource Convert(Trip trip);
    }
}