using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Application.Common.Exceptions;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;

namespace Hiker.Application.Features.Trips.Commands.AddTripParticipant
{
    public class AddTripParticipantCommandHandler : AsyncRequestHandler<AddTripParticipantCommand>
    {
        private readonly ITripParticipantRepository _tripParticipantRepository;
        private readonly ITripsRepository _tripsRepository;
        private readonly IUserRepository _userRepository;

        public AddTripParticipantCommandHandler(ITripParticipantRepository tripParticipantRepository, IUserRepository userRepository, ITripsRepository tripsRepository)
        {
            _tripParticipantRepository = tripParticipantRepository;
            _userRepository = userRepository;
            _tripsRepository = tripsRepository;
        }

        protected override async Task Handle(AddTripParticipantCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetAsync(x => x.Id == request.TripParticipant.UserId) == null)
            {
                throw new EntityNotFoundException($"User with Id {request.TripParticipant.UserId} doesn't exist.");
            }

            var trip = await _tripsRepository.GetDetailsByIdAsync(request.TripParticipant.TripId);
            if (trip == null)
            {
                throw new EntityNotFoundException($"Trip with Id {request.TripParticipant.UserId} doesn't exist.");
            }

            if (trip.TripParticipants.SingleOrDefault(x => x.UserId == request.TripParticipant.UserId) != null
                || trip.AuthorId == request.TripParticipant.UserId)
            {
                throw new UniqueConstraintViolatedException($"User with Id {request.TripParticipant.UserId} already participates in trip with Id {request.TripParticipant.TripId}.");
            }
            await _tripParticipantRepository.AddAsync(request.TripParticipant);
        }
    }
}