using System.Linq;
using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class TripBriefResourceConverter : ITripBriefResourceConverter
    {
        private readonly IMapper _mapper;

        public TripBriefResourceConverter()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Trip, TripBriefResource>()
                    .ForMember(x => x.TripParticipants, opt => opt.Ignore());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public TripBriefResource Convert(Trip trip)
        {
            var tripBriefResource = _mapper.Map<TripBriefResource>(trip);
            tripBriefResource.TripParticipants = new UserBriefResource
            {
                Count = trip.TripParticipants.Count()
            };
            return tripBriefResource;
        }
    }
}