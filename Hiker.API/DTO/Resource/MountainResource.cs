using System.Collections.Generic;

namespace Hiker.API.DTO.Resource
{
    public class MountainResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MetersAboveSeaLevel { get; set; }
        public IEnumerable<MountainTrailResource> Trails { get; set; }
        public LocationResource Location { get; set; }
    }
}