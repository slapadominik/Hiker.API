using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Trips.Commands.DeleteTrip
{
    public class DeleteTripCommandHandler : AsyncRequestHandler<DeleteTripCommand>
    {
        private readonly ITripsRepository _tripsRepository;

        public DeleteTripCommandHandler(ITripsRepository tripsRepository)
        {
            _tripsRepository = tripsRepository;
        }

        protected override async Task Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _tripsRepository.GetBriefByIdAsync(request.TripId);
            if (trip != null)
            {
                _tripsRepository.Delete(trip);
            }
        }
    }
}