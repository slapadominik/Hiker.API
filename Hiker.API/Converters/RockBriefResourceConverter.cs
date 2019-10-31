using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class RockBriefResourceConverter : IRockBriefResourceConverter
    {
        private readonly IMapper _mapper;

        public RockBriefResourceConverter(IValueConverter<Location, LocationResource> locationResourceConverter)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rock, RockBriefResource>()
                    .ForMember(x => x.Location, opt => opt.ConvertUsing(locationResourceConverter));
            });

            _mapper = mapperConfig.CreateMapper();
        }
        public RockBriefResource Convert(Rock rock)
        {
            var rockResource = _mapper.Map<RockBriefResource>(rock);
            
            return rockResource;
        }
    }
}