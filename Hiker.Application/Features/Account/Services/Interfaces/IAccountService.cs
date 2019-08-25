using System.Threading.Tasks;
using Hiker.Application.Features.Account.DTO;

namespace Hiker.Application.Features.Account.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AuthorizationTokens> FacebookLoginAsync(FacebookLogin facebookLoginResource);
    }
}