namespace Hiker.API.DTO.Resource
{
    public class TripDestinationResource
    {
        public int? Id { get; set; }
        public TripDestinationType Type { get; set; }
        public int? MountainId { get; set; }
        public int? RockId { get; set; }
    }
}