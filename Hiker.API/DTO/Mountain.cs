using System.Collections.Generic;

namespace Hiker.API.DTO
{
    public class Mountain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MetersAboveSeaLevel { get; set; }
        public IEnumerable<MountainTrail> Trails { get; set; }
        public Location Location { get; set; }
    }
}