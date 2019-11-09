using System;
using Hiker.API.DTO.Resource.Command;
using Hiker.Application.Features.Trips.Commands.AddTripParticipant;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters.Interfaces
{
    public interface ITripParticipantConverter
    {
        TripParticipant Convert(Guid userId, int tripId);
    }
}