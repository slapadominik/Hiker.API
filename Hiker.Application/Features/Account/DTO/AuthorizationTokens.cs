namespace Hiker.Application.Features.Account.DTO
{
    public class AuthorizationTokens
    {
        public Token AccessToken { get; set; }
        public Token RefreshToken { get; set; }
    }
}