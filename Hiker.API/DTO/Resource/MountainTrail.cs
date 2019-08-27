namespace Hiker.API.DTO.Resource
{
    public class MountainTrail
    {
        public int Id { get; set; }
        public int MountainId { get; set; }
        public TrailColor Color { get; set; }
        public float AverageTime { get; set; }
        public int Difficulty { get; set; }
    }
}