using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Trips.Commands.UpdateTrip
{
    public class UpdateTripCommand : IRequest
    {
        public UpdateTripCommand(Trip trip)
        {
            Trip = trip;
        }

        public Trip Trip { get;  }
    }
}