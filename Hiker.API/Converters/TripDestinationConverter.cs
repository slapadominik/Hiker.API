using System;
using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Persistence.DAO;
using TripDestinationType = Hiker.API.DTO.Resource.TripDestinationType;

namespace Hiker.API.Converters
{
    public class TripDestinationConverter : ITripDestinationConverter
    {
        private readonly IMapper _mapper;
        private readonly IMountainBriefResourceConverter _mountainBriefResourceConverter;
        private readonly IRockBriefResourceConverter _rockBriefResourceConverter;

        public TripDestinationConverter(IMountainBriefResourceConverter mountainBriefResourceConverter, IRockBriefResourceConverter rockBriefResourceConverter)
        {
            _mountainBriefResourceConverter = mountainBriefResourceConverter;
            _rockBriefResourceConverter = rockBriefResourceConverter;
            var mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TripDestinationResource, TripDestination>()
                    .ForMember(x => x.TripDestinationTypeId, opt => opt.MapFrom(src => (int) src.Type))
                    .ForMember(x => x.TripId, opt => opt.Ignore())
                    .ForMember(x => x.Mountain, opt => opt.Ignore())
                    .ForMember(x => x.Rock, opt => opt.Ignore());

                cfg.CreateMap<TripDestination, TripDestinationResource>()
                    .ForMember(x => x.Type, opt => opt.MapFrom(src => src.TripDestinationTypeId))
                    .ForMember(x => x.Mountain, opt => opt.Ignore())
                    .ForMember(x => x.Rock, opt => opt.Ignore());


                cfg.CreateMap<TripDestinationBriefResource, TripDestination>()
                    .ForMember(x => x.TripDestinationTypeId, opt => opt.MapFrom(src => (int) src.Type))
                    .ForMember(x => x.TripId, opt => opt.Ignore());
            });

            _mapper = mapperCfg.CreateMapper();
        }

        public TripDestination Convert(TripDestinationBriefResource tripDestinationBrief)
        {
            return _mapper.Map<TripDestination>(tripDestinationBrief);
        }

        public TripDestinationResource Convert(TripDestination tripDestination)
        {
            var result = _mapper.Map<TripDestinationResource>(tripDestination);
            if (result.Type == TripDestinationType.Mountain)
            {
                result.Mountain = _mountainBriefResourceConverter.Convert(tripDestination.Mountain);
            }
            else if (result.Type == TripDestinationType.Rock)
            {
                result.Rock = _rockBriefResourceConverter.Convert(tripDestination.Rock);
            }
            return result;
        }

        public TripDestination Convert(TripDestinationResource tripDestinationResource)
        {
            var result = _mapper.Map<TripDestination>(tripDestinationResource);
            if (tripDestinationResource.Type == TripDestinationType.Mountain)
            {
                result.MountainId = tripDestinationResource.Mountain.Id;
            }
            else if (tripDestinationResource.Type == TripDestinationType.Rock)
            {
                result.RockId = tripDestinationResource.Rock.Id;
            }
            return result;
        }
    }
}