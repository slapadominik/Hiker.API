using System.Threading;
using System.Threading.Tasks;
using Hiker.Application.Common.Exceptions;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

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
            if (await _userRepository.Get(x => x.Id == request.TripParticipant.UserId) == null)
            {
                throw new EntityNotFoundException($"User with Id {request.TripParticipant.UserId} doesn't exist.");
            }

            if (await _tripsRepository.GetByIdAsync(request.TripParticipant.TripId) == null)
            {
                throw new EntityNotFoundException($"Trip with Id {request.TripParticipant.UserId} doesn't exist.");
            }
            await _tripParticipantRepository.AddAsync(request.TripParticipant);
        }
    }
}