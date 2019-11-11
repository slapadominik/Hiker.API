using System.Linq;
using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.Application.Common.Consts;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class MountainResourceConverter : IMountainResourceConverter
    {
        private readonly IMapper _mapper;
        private readonly IMountainTrailResourceConverter _mountainTrailResourceConverter;

        public MountainResourceConverter(IValueConverter<Location, LocationResource> locationResourceConverter, IMountainTrailResourceConverter mountainTrailResourceConverter)
        {
            _mountainTrailResourceConverter = mountainTrailResourceConverter;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mountain, MountainResource>()
                    .ForMember(x => x.MountainImages, 
                        opt => opt.MapFrom(src => src.MountainImages.Select(y => ImageResource.ForMountain(y.ImageId.ToString(), y.FileExtensions))))
                    .ForMember(x => x.Location, opt => opt.ConvertUsing(locationResourceConverter))
                    .ForMember(x => x.Trails, opt => opt.Ignore());
            });
            _mapper = mapperConfig.CreateMapper();
        }

        public MountainResource Convert(Mountain mountain)
        {
            var mountainResource = _mapper.Map<MountainResource>(mountain);
            mountainResource.Trails = mountain.MountainTrail.Select(x => _mountainTrailResourceConverter.Convert(x));
            return mountainResource;
        }
    }
}