namespace Hiker.Application.Features.Authentication.DTO
{
    public class LoginQuery
    {
        public string Token { get; }

        public LoginQuery(string token)
        {
            Token = token;
        }
    }
}