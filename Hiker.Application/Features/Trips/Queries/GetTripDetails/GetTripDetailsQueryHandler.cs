using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Trips.Queries.GetTripDetails
{
    public class GetTripDetailsQueryHandler : IRequestHandler<GetTripDetailsQuery, Trip>
    {
        private readonly ITripsRepository _tripsRepository;

        public GetTripDetailsQueryHandler(ITripsRepository tripsRepository)
        {
            _tripsRepository = tripsRepository;
        }

        public Task<Trip> Handle(GetTripDetailsQuery request, CancellationToken cancellationToken)
        {
            return _tripsRepository.GetByIdAsync(request.TripId);
        }
    }
}