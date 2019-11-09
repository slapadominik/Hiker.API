using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Trips.Commands.AddTripParticipant
{
    public class AddTripParticipantCommand : IRequest
    {
        public TripParticipant TripParticipant { get; }

        public AddTripParticipantCommand(TripParticipant tripParticipant)
        {
            TripParticipant = tripParticipant;
        }
    }
}