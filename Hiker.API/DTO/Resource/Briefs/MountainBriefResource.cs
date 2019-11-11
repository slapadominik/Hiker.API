using System.Collections;
using System.Collections.Generic;

namespace Hiker.API.DTO.Resource.Briefs
{
    public class MountainBriefResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MetersAboveSeaLevel { get; set; }
        public LocationResource Location { get; set; }
        public int UpcomingTripsCount { get; set; }
        public MountainTrailBriefResource Trails { get; set;  }
    }
}