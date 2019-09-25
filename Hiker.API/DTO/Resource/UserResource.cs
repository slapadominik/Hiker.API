using System;

namespace Hiker.API.DTO.Resource
{
    public class UserResource
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public string FacebookId { get; set; }
    }
}