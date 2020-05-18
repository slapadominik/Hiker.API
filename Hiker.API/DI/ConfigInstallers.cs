using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiker.API.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hiker.API.DI
{
    public static class ConfigInstallers
    {
        public static void InstallConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ResourcesOptions>(configuration.GetSection("Resources"));
        }
    }
}
