namespace Hiker.API.DTO
{
    public class TripDestination
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public TripDestinationType Type { get; set; }
        public int? MountainId { get; set; }
        public Location CustomLocation { get; set; }
    }
}