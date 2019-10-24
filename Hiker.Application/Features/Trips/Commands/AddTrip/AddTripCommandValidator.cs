using FluentValidation;
using FluentValidation.Results;
using Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation;

namespace Hiker.Application.Features.Trips.Commands.AddTrip
{
    public class AddTripCommandValidator : AbstractValidator<AddTripCommand>
    {
        public AddTripCommandValidator()
        {
            RuleForEach(x => x.Trip.TripDestinations).SetValidator(new TripDestinationValidator());
        }
    }
}