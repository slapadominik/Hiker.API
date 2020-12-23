using Hiker.Application.Features.Authentication.DTO;

namespace Hiker.API.DTO.Resource.Query
{
    public class LoginQueryResource
    {
        public string Token { get; set; }
        public UserResource User { get; set; }
    }
}