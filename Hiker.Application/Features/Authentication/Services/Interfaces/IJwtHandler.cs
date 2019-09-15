using System;
using Hiker.Application.Features.Authentication.DTO;

namespace Hiker.Application.Features.Authentication.Services.Interfaces
{
    public interface IJwtHandler
    {
        Token CreateAccessToken(Guid userId, string email);

        Token CreateRefreshToken(Guid userId);
    }
}