using System.Data;
using FluentValidation;
using FluentValidation.Results;
using Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation;
using Hiker.Persistence.DAO;

namespace Hiker.Application.Features.Trips.Commands.AddTrip
{
    public class AddTripCommandValidator : AbstractValidator<AddTripCommand>
    {
        public AddTripCommandValidator()
        {
            RuleForEach(x => x.Trip.TripDestinations).SetValidator(new TripDestinationValidator());
            RuleFor(x => x.Trip).SetValidator(new TripValidator());
        }
    }

    public class TripValidator : AbstractValidator<Trip>
    {
        public TripValidator()
        {
            RuleFor(x => x.DateTo)
                .Must(x => !x.HasValue)
                .When(x => x.IsOneDay);

            RuleFor(x => x.DateTo)
                .Must(x => x.HasValue)
                .When(x => !x.IsOneDay);

            RuleFor(x => x.AuthorId)
                .Must(x => x.HasValue);

            RuleFor(x => x.TripTitle)
                .NotNull()
                .NotEmpty();
        }
    }
}