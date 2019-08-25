using System;
using Hiker.Application.Features.Account.DTO;

namespace Hiker.Application.Features.Account.Services.Interfaces
{
    public interface IJwtHandler
    {
        Token CreateAccessToken(Guid userId, string email);

        Token CreateRefreshToken(Guid userId);
    }
}