using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Trips.Commands.AddTrip
{
    public class AddTripCommand : IRequest<int>
    {
        public Trip Trip { get; }
        public AddTripCommand(Trip trip)
        {
            Trip = trip;
        }
    }
}