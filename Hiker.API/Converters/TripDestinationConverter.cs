using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class TripDestinationConverter : ITripDestinationConverter
    {
        private readonly IMapper _mapper;

        public TripDestinationConverter()
        {
            var mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TripDestinationResource, TripDestination>()
                    .ForMember(x => x.TripDestinationTypeId, opt => opt.MapFrom(src => (int) src.Type))
                    .ForMember(x => x.TripId, opt => opt.Ignore());
            });

            _mapper = mapperCfg.CreateMapper();
        }

        public TripDestination Convert(TripDestinationResource tripDestinationResource)
        {
            return _mapper.Map<TripDestination>(tripDestinationResource);
        }
    }
}