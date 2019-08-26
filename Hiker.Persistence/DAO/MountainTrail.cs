namespace Hiker.Persistence.DAO
{
    public class MountainTrail
    {
        public int Id { get; set; }
        public int AverageTimeMinutes { get; set; }
        public int Difficulty { get; set; }
        public MountainTrailColor Color { get; set; }
        public int ColorId { get; set; }
    }
}