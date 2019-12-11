using System;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Application.Common.Consts;
using Hiker.Application.Common.Exceptions;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Trips.Commands.UpdateTrip
{
    public class UpdateTripCommandHandler : AsyncRequestHandler<UpdateTripCommand>
    {
        private readonly ITripsRepository _tripsRepository;
        private readonly IMountainsRepository _mountainsRepository;
        private readonly ITripDestinationRepository _tripDestinationRepository;

        public UpdateTripCommandHandler(ITripsRepository tripsRepository,
            IMountainsRepository mountainsRepository, 
            ITripDestinationRepository tripDestinationRepository)
        {
            _tripsRepository = tripsRepository;
            _mountainsRepository = mountainsRepository;
            _tripDestinationRepository = tripDestinationRepository;
        }

        protected override Task Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            if (request.Trip == null)
            {
                throw new ArgumentNullException();
            }

            var trip = _tripsRepository.Exists(request.Trip.Id);
            if (!trip)
            {
                throw new EntityNotFoundException($"Not found trip with id: {request.Trip.Id}");
            }

            foreach (var destination in request.Trip.TripDestinations)
            {
                if (destination.TripDestinationTypeId == (int) TripDestinationType.Mountain && destination.MountainId != null)
                {
                    if (!_mountainsRepository.Exists(destination.MountainId.Value))
                    {
                        throw new EntityNotFoundException($"Not found mountain with id: {destination.MountainId.Value}");
                    }
                }
                else
                {
                    throw new ValidationException();
                }
            }
            _tripDestinationRepository.Delete(request.Trip.Id);
            _tripsRepository.Update(request.Trip);
            return Task.CompletedTask;
        }
    }
}