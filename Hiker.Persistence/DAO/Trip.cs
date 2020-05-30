using System;
using System.Collections.Generic;

namespace Hiker.Persistence.DAO
{
    public class Trip
    {
        public int Id { get; set; }
        public string TripTitle { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool IsOneDay { get; set; }
        public string Description { get; set; }
        public User Author { get; set; }
        public Guid? AuthorId { get; set; }
        public IEnumerable<TripDestination> TripDestinations { get; set; }
        public IEnumerable<TripParticipant> TripParticipants { get; set; }

        public Trip()
        {
            TripDestinations = new List<TripDestination>();
            TripParticipants = new List<TripParticipant>();
        }
    }
}