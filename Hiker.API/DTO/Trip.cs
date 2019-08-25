using System;
using System.Collections;
using System.Collections.Generic;

namespace Hiker.API.DTO
{
    public class Trip
    {
        public int Id { get; set; }
        public string TripTitle { get; set; }
        public Guid AuthorId { get; set; }
        public int DurationDays { get; set; }
        public int MaxParticipants { get; set; }
        public string Description { get; set; }
        public IEnumerable<TripDestination> Destinations { get; set; }
        public IEnumerable<User> Participants { get; set; }
    }
}