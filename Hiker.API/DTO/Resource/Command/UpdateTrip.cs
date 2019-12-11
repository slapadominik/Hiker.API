using System;
using System.Collections.Generic;
using Hiker.API.DTO.Resource.Briefs;

namespace Hiker.API.DTO.Resource.Command
{
    public class UpdateTrip
    {
        public string TripTitle { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public IEnumerable<TripDestinationBriefResource> TripDestinations { get; set; }
    }
}