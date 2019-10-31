using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters.Interfaces
{
    public interface ITripDestinationConverter
    {
        TripDestination Convert(TripDestinationResource tripDestinationResource);

        TripDestination Convert(TripDestinationBriefResource tripDestinationBrief);

        TripDestinationResource Convert(TripDestination tripDestination);
    }
}