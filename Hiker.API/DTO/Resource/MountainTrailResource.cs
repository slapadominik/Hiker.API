namespace Hiker.API.DTO.Resource
{
    public class MountainTrailResource
    {
        public int Id { get; set; }
        public int MountainId { get; set; }
        public TrailColorResource ColorResource { get; set; }
        public float AverageTime { get; set; }
        public int Difficulty { get; set; }
    }
}