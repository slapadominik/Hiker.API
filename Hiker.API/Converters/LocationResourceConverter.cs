using AutoMapper;
using Hiker.API.DTO.Resource;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class LocationResourceConverter : IValueConverter<Location, LocationResource>
    {
        private readonly IMapper _mapper;
        public LocationResourceConverter()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Location, LocationResource>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        public LocationResource Convert(Location sourceMember, ResolutionContext context)
        {
            return _mapper.Map<LocationResource>(sourceMember);
        }
    }
}