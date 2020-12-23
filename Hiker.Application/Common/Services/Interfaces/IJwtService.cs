using System;
using Hiker.Persistence.DAO;

namespace Hiker.Application.Common.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(Guid userId);
    }
}