using System.Linq;
using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Query;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class TripDetailsResourceConverter : ITripResourceConverter
    {
        private readonly IMapper _mapper;
        private readonly IUserBriefResourceConverter _userBriefResourceConverter;
        private readonly ITripDestinationConverter _tripDestinationConverter;
        
        public TripDetailsResourceConverter(ITripDestinationConverter tripDestinationConverter, IUserBriefResourceConverter userBriefResourceConverter)
        {
            _tripDestinationConverter = tripDestinationConverter;
            _userBriefResourceConverter = userBriefResourceConverter;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Trip, TripQueryResource>()
                    .ForMember(x => x.TripParticipants, opt => opt.Ignore())
                    .ForMember(x => x.TripDestinations, opt => opt.Ignore())
                    .ForMember(x => x.Author, opt => opt.Ignore());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public TripQueryResource Convert(Trip trip)
        {
            var tripResource = _mapper.Map<TripQueryResource>(trip);
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