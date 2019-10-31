using System;

namespace Hiker.API.DTO.Resource.Briefs
{
    public class UserBriefResource
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}