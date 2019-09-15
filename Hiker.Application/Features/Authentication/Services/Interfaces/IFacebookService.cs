using System.Threading.Tasks;
using Hiker.Application.Features.Authentication.DTO;

namespace Hiker.Application.Features.Authentication.Services.Interfaces
{
    public interface IFacebookService
    {
        Task<FacebookUser> GetUserFromFacebookAsync(string facebookToken);
    }
}