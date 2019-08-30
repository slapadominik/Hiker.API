﻿using AutoMapper;
using Hiker.API.Converters;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.Persistence.DAO;
using Microsoft.Extensions.DependencyInjection;

namespace Hiker.API.DI
{
    public static class ConvertersInstaller
    {
        public static void InstallConverters(this IServiceCollection services)
        {
            services.AddTransient<IValueConverter<Location, LocationResource>, LocationResourceConverter>();
            services.AddTransient<IMountainBriefResourceConverter, MountainBriefResourceConverter>();
        }
    }
}