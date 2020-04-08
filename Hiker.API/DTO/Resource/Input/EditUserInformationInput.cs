using System;

namespace Hiker.API.DTO.Resource.Input
{
    public class EditUserInformationInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string AboutMe { get; set; }
        public string PhoneNumber { get; set; }
    }
}