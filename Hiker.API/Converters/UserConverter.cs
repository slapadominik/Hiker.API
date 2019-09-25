using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class UserConverter : IUserConverter
    {
        private readonly IMapper _mapper;

        public UserConverter()
        {
            var mapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserResource>(); });
            _mapper = mapperConfig.CreateMapper();
        }

        public UserResource Convert(User user)
        {
            return _mapper.Map<UserResource>(user);
        }
    }
}