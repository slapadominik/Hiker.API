using System;
using System.Collections.Generic;
using Hiker.API.DTO.Resource.Briefs;

namespace Hiker.API.DTO.Resource.Query
{
    public class TripQueryResource
    {
        public int Id { get; set; }
        public string TripTitle { get; set; }
        public UserBriefQueryResource Author { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public IEnumerable<TripDestinationResource> TripDestinations { get; set; }
        public IEnumerable<UserBriefQueryResource> TripParticipants { get; set; }

        public TripQueryResource()
        {
            TripDestinations = new List<TripDestinationResource>();
            TripParticipants = new List<UserBriefQueryResource>();
        }
    }
}