using FluentValidation;

namespace Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation
{
    public class GetMountainsNearbyLocationQueryValidator : AbstractValidator<GetMountainsNearbyLocationQuery>
    {
        public GetMountainsNearbyLocationQueryValidator()
        {
            RuleFor(x => x.Latitude).Must(x => x <= 90 && x >= -90);
            RuleFor(x => x.Longitude).Must(x => x <= 90 && x >= -90);
        }
    }
}