namespace Hiker.Persistence.DAO
{
    public class MountainTrail
    {
        public int Id { get; set; }
        public int TimeToTopMinutes { get; set; }
        public MountainTrailColor Color { get; set; }
        public int ColorId { get; set; }
    }
}