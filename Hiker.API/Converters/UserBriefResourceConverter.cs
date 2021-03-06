﻿using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class UserBriefResourceConverter : IUserBriefResourceConverter
    {
        private readonly IMapper _mapper;
        
        public UserBriefResourceConverter()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserBriefQueryResource>()
                    .ForMember(x => x.ProfilePictureUrl, opt => opt.Ignore());
            });

            _mapper = mapperConfig.CreateMapper();
        }
        public UserBriefQueryResource Convert(User user)
        {
            var userBrief = _mapper.Map<UserBriefQueryResource>(user);
            if (!string.IsNullOrEmpty(user.FacebookId))
            {
                userBrief.ProfilePictureUrl = $"{Consts.FacebookAPI}{user.FacebookId}/picture?width=300&height=300";
            }
            return userBrief;
        }
    }
}