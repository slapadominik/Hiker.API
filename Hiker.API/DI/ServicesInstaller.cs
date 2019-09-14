using Hiker.Application.Common;
using Hiker.Application.Common.Services;
using Hiker.Application.Common.Services.Interfaces;
using Hiker.Application.Features.Account.Services;
using Hiker.Application.Features.Account.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace Hiker.API.DI
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IServiceCollection services)
        {
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IFacebookService, FacebookService>();
            services.AddTransient<IRestClient, RestClient>();
        }
    }
}