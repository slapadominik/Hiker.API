using System;
using System.Collections.Generic;

namespace Hiker.API.DTO.Resource
{
    public class TripResource
    {
        public int? Id { get; set; }
        public string TripTitle { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public IEnumerable<TripDestinationResource> TripDestinations { get; set; }
        public IEnumerable<UserResource> TripParticipants { get; set; }
    }
}