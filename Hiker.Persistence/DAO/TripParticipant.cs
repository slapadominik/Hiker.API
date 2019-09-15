using System;

namespace Hiker.Persistence.DAO
{
    public class TripParticipant
    {
        public Trip Trip { get; set; }
        public int TripId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}