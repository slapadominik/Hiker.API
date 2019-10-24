using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters.Interfaces
{
    public interface ITripBriefResourceConverter
    {
        TripBriefResource Convert(Trip trip);
    }
}