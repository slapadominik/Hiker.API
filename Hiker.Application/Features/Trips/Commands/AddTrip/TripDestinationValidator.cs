using FluentValidation;
using Hiker.Persistence.DAO;

namespace Hiker.Application.Features.Trips.Commands.AddTrip
{
    public class TripDestinationValidator : AbstractValidator<TripDestination>
    {
        private const int Mountain = 1;
        private const int Rock = 2;

        public TripDestinationValidator()
        {
            RuleFor(x => x.MountainId).NotNull().When(x => x.TripDestinationTypeId == Mountain);
            RuleFor(x => x.RockId).NotNull().When(x => x.TripDestinationTypeId == Rock);
        }
    }
}