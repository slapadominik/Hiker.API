using System;
using System.Threading.Tasks;
using Hiker.Application.Features.Authentication.DTO;

namespace Hiker.Application.Features.Authentication.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Guid> RegisterUserFromFacebookAsync(FacebookToken facebookTokenResource);
        Task<LoginQueryResponse> LoginAsync(LoginQuery query);
    }
}