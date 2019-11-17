using MediatR;

namespace Hiker.Application.Features.Trips.Commands.DeleteTrip
{
    public class DeleteTripCommand : IRequest
    {
        public int TripId { get; }

        public DeleteTripCommand(int tripId)
        {
            TripId = tripId;
        }
    }
}