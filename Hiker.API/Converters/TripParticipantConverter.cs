using System;
using Hiker.API.Converters.Interfaces;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class TripParticipantConverter : ITripParticipantConverter
    {
        public TripParticipant Convert(Guid userId, int tripId)
        {
            return new TripParticipant {TripId = tripId, UserId = userId};
        }
    }
}