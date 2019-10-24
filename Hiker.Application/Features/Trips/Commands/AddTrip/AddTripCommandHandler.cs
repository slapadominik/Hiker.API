using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Trips.Commands.AddTrip
{
    public class AddTripCommandHandler : IRequestHandler<AddTripCommand, int>
    {
        private readonly ITripsRepository _tripsRepository;

        public AddTripCommandHandler(ITripsRepository tripsRepository)
        {
            _tripsRepository = tripsRepository;
        }

        public Task<int> Handle(AddTripCommand request, CancellationToken cancellationToken)
        {
            return _tripsRepository.AddAsync(request.Trip);
        }
    }
}