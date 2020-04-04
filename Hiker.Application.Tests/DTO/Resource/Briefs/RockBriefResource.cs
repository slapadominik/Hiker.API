namespace Hiker.API.DTO.Resource.Briefs
{
    public class RockBriefResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationResource Location { get; set; }
    }
}