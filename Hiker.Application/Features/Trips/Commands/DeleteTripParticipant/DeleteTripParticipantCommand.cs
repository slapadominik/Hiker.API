using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Trips.Commands.DeleteTripParticipant
{
    public class DeleteTripParticipantCommand : IRequest
    {
        public TripParticipant TripParticipant { get; }

        public DeleteTripParticipantCommand(TripParticipant tripParticipant)
        {
            TripParticipant = tripParticipant;
        }
    }
}