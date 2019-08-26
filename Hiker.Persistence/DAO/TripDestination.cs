namespace Hiker.Persistence.DAO
{
    public class TripDestination
    {
        public int Id { get; set; }
        public Trip Trip { get; set; }
        public int TripId { get; set; }
        public TripDestinationType TripDestinationType { get; set; }
        public int TripDestinationTypeId { get; set; }
        public Mountain Mountain { get; set; }
        public int? MountainId { get; set; }
        public Location CustomLocation { get; set; }
        public int? CustomLocationId { get; set; }
    }
}