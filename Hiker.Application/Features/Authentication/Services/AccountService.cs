using System;
using System.Threading.Tasks;
using Hiker.Application.Common.Exceptions;
using Hiker.Application.Features.Authentication.DTO;
using Hiker.Application.Features.Authentication.Services.Interfaces;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;

namespace Hiker.Application.Features.Authentication.Services
{
    public class AccountService : IAccountService
    {
        private readonly IFacebookService _facebookService;
        private readonly IUserRepository _userRepository;

        public AccountService(
            IFacebookService facebookService,
            IUserRepository userRepository)
        {
            _facebookService = facebookService;
            _userRepository = userRepository;
        }

        public async Task<Guid> RegisterUserFromFacebookAsync(FacebookToken facebookTokenResource)
        {
            if (string.IsNullOrEmpty(facebookTokenResource.Token))
            {
                throw new ValidationException();
            }

            var facebookUser = await _facebookService.GetUserFromFacebookAsync(facebookTokenResource.Token);
            if (facebookUser == null)
            {
                throw new RemoteEntityNotFoundException($"User not found with FacebookToken: {facebookTokenResource.Token}");
            }
            var user = await _userRepository.GetByFacebookIdAsync(facebookUser.FacebookId);
            if (user != null)
            {
                throw new EntityExistsException($"User with FacebookToken: {facebookTokenResource.Token} already exists.");
            }
            return await _userRepository.AddAsync(new User
            {
                Email = facebookUser.Email,
                FirstName = facebookUser.FirstName,
                LastName = facebookUser.LastName,
                FacebookId = facebookUser.FacebookId
            });
        }
    }
}