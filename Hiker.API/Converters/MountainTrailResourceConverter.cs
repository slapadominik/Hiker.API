using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class MountainTrailResourceConverter : IMountainTrailResourceConverter
    {
        private readonly IMapper _mapper;

        public MountainTrailResourceConverter()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MountainTrail, MountainTrailResource>()
                    .ForMember(x => x.Color, opt => opt.MapFrom(src => src.Color.ColorName));
            });

            _mapper = mapperConfig.CreateMapper();
        }
        public MountainTrailResource Convert(MountainTrail trail)
        {
            return _mapper.Map<MountainTrailResource>(trail);
        }
    }
}