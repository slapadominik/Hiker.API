using System.Linq;
using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class TripResourceConverter : ITripResourceConverter
    {
        private readonly IMapper _mapper;
        private readonly IUserBriefResourceConverter _userBriefResourceConverter;
        private readonly ITripDestinationConverter _tripDestinationConverter;
        
        public TripResourceConverter(ITripDestinationConverter tripDestinationConverter, IUserBriefResourceConverter userBriefResourceConverter)
        {
            _tripDestinationConverter = tripDestinationConverter;
            _userBriefResourceConverter = userBriefResourceConverter;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Trip, TripResource>()
                    .ForMember(x => x.TripParticipants, opt => opt.Ignore())
                    .ForMember(x => x.TripDestinations, opt => opt.Ignore())
                    .ForMember(x => x.Author, opt => opt.Ignore());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public TripResource Convert(Trip trip)
        {
            var tripResource = _mapper.Map<TripResource>(trip);
            tripResource.TripParticipants = trip.TripParticipants?.Select(x => _userBriefResourceConverter.Convert(x.User));
            tripResource.TripDestinations = trip.TripDestinations?.Select(x => _tripDestinationConverter.Convert(x));
            if (trip.Author != null)
            {
                tripResource.Author = _userBriefResourceConverter.Convert(trip.Author);
            }
            return tripResource;
        }
    }
}