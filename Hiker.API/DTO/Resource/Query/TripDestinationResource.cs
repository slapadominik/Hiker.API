using Hiker.API.DTO.Resource.Briefs;

namespace Hiker.API.DTO.Resource
{
    public class TripDestinationResource
    {
        public int Id { get; set; }
        public TripDestinationType Type { get; set; }
        public MountainBriefResource Mountain { get; set; }
        public RockBriefResource Rock { get; set; }
    }
}