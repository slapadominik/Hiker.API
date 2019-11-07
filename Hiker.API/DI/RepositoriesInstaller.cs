using Hiker.Persistence.Repositories;
using Hiker.Persistence.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hiker.API.DI
{
    public static class RepositoriesInstaller
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMountainsRepository, MountainsRepository>();
            services.AddTransient<ITripsRepository, TripsRepository>();
            services.AddTransient<ITripDestinationRepository, TripDestinationRepository>();
        }
    }
}