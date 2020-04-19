using System;

namespace Hiker.API.DTO.Resource.Briefs
{
    public class UserBriefQueryResource
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}