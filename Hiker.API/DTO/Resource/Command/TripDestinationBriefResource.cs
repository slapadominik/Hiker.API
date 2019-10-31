namespace Hiker.API.DTO.Resource.Briefs
{
    public class TripDestinationBriefResource
    {
        public TripDestinationType Type { get; set; }
        public int? MountainId { get; set; }
        public int? RockId { get; set; }
    }
}