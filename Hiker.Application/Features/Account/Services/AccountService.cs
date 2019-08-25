using System;
using System.Threading.Tasks;
using Hiker.Application.Features.Account.DTO;
using Hiker.Application.Features.Account.Services.Interfaces;

namespace Hiker.Application.Features.Account.Services
{
    public class AccountService : IAccountService
    {
        private readonly IFacebookService _facebookService;
        private readonly IJwtHandler _jwtHandler;

        public AccountService(IFacebookService facebookService, IJwtHandler jwtHandler)
        {
            _facebookService = facebookService;
            _jwtHandler = jwtHandler;
        }

        public async Task<AuthorizationTokens> FacebookLoginAsync(FacebookLogin facebookLoginResource)
        {
            if (string.IsNullOrEmpty(facebookLoginResource.FacebookToken))
            {
                throw new Exception("Token is null or empty");
            }

            var facebookUser = await _facebookService.GetUserFromFacebookAsync(facebookLoginResource.FacebookToken);

            return CreateAccessTokens(facebookUser);
        }

        private AuthorizationTokens CreateAccessTokens(FacebookUser user)
        {
            var userId = Guid.NewGuid();
            var accessToken = _jwtHandler.CreateAccessToken(userId, user.Email);
            var refreshToken = _jwtHandler.CreateRefreshToken(userId);

            return new AuthorizationTokens { AccessToken = accessToken, RefreshToken = refreshToken };
        }
    }
}