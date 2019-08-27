﻿using System.Collections.Generic;

namespace Hiker.Persistence.DAO
{
    public class Trip
    {
        public int Id { get; set; }
        public string TripTitle { get; set; }
        public int DurationDays { get; set; }
        public int MaxParticipants { get; set; }
        public string Description { get; set; }
        public IEnumerable<TripDestination> TripDestinations { get; set; }

        public Trip()
        {
            TripDestinations = new List<TripDestination>();
        }
    }
}