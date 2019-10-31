using System.Collections.Generic;
using Hiker.API.DTO.Resource.Briefs;

namespace Hiker.API.DTO.Resource
{
    public class TripDestinationsResource
    {
        public IEnumerable<MountainBriefResource> Mountains { get; set; }
        public IEnumerable<RockBriefResource> Rocks { get; set; }
    }
}