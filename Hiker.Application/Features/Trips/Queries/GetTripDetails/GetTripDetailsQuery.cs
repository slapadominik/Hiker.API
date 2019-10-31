using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Trips.Queries.GetTripDetails
{
    public class GetTripDetailsQuery : IRequest<Trip>
    {
        public int TripId { get; }

        public GetTripDetailsQuery(int tripId)
        {
            TripId = tripId;
        }
    }
}