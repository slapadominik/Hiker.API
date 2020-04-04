using System;
using System.Linq;
using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class MountainBriefResourceConverter : IMountainBriefResourceConverter
    {
        private readonly IMapper _mapper;
        private readonly ILocationConverter _locationConverter;

        public MountainBriefResourceConverter(ILocationConverter locationConverter)
        {
            _locationConverter = locationConverter;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mountain, MountainBriefResource>()
                    .ForMember(x => x.Location, opt => opt.Ignore())
                    .ForMember(x => x.Trails, opt => opt.Ignore());
            });
            _mapper = mapperConfig.CreateMapper();
        }

        public MountainBriefResource Convert(Mountain mountain)
        {
            var result = _mapper.Map<MountainBriefResource>(mountain);
            result.UpcomingTripsCount = mountain.TripDestinations.Count(x => x.Trip.DateFrom > DateTime.Now);
            result.Location = _locationConverter.Convert(mountain.Latitude, mountain.Longitude, mountain.Location.RegionName);
            if (mountain.MountainTrail != null)
            {
                result.Trails = new MountainTrailBriefResource
                {
                    Href = $"/api/mountains/{mountain.Id}/trails",
                    Count = mountain.MountainTrail.Count()
                };
            }
          
            return result;
        }
    }
}