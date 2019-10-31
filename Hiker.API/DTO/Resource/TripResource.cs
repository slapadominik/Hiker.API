using System;
using System.Collections.Generic;
using Hiker.API.DTO.Resource.Briefs;

namespace Hiker.API.DTO.Resource
{
    public class TripResource
    {
        public int? Id { get; set; }
        public string TripTitle { get; set; }
        public UserBriefResource Author { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public IEnumerable<TripDestinationResource> TripDestinations { get; set; }
        public IEnumerable<UserBriefResource> TripParticipants { get; set; }

        public TripResource()
        {
            TripDestinations = new List<TripDestinationResource>();
            TripParticipants = new List<UserBriefResource>();
        }
    }
}