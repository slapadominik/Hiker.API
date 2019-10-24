using FluentValidation;
using Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation;
using Hiker.Application.Features.Trips.Commands.AddTrip;
using Microsoft.Extensions.DependencyInjection;

namespace Hiker.API.DI
{
    public static class ValidatorsInstaller
    {
        public static void InstallValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<GetMountainsNearbyLocationQuery>, GetMountainsNearbyLocationQueryValidator>();
            services.AddTransient<IValidator<AddTripCommand>, AddTripCommandValidator>();
        }
    }
}