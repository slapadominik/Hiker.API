using System.Threading;
using System.Threading.Tasks;
using Hiker.Application.Common.Exceptions;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Trips.Commands.DeleteTripParticipant
{
    public class DeleteTripParticipantCommandHandler : AsyncRequestHandler<DeleteTripParticipantCommand>
    {
        private readonly ITripParticipantRepository _tripParticipantRepository;
  

        public DeleteTripParticipantCommandHandler(ITripParticipantRepository tripParticipantRepository)
        {
            _tripParticipantRepository = tripParticipantRepository;
        }

        protected override async Task Handle(DeleteTripParticipantCommand request, CancellationToken cancellationToken)
        {
            var tripParticipant = await _tripParticipantRepository.GetAsync(request.TripParticipant.UserId,
                request.TripParticipant.TripId);
            if (tripParticipant == null)
            {
                throw new EntityNotFoundException($"User with Id {request.TripParticipant.UserId} doesn't take part in trip with Id {request.TripParticipant.TripId}");
            }

            await _tripParticipantRepository.DeleteAsync(tripParticipant);
        }
    }
}