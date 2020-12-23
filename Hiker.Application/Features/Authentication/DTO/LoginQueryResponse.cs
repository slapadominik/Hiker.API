using System;
using Hiker.Persistence.DAO;

namespace Hiker.Application.Features.Authentication.DTO
{
    public class LoginQueryResponse
    {
        public LoginQueryResponse(string token, User user)
        {
            Token = token;
            User = user;
        }

        public string Token { get; }
        public User User { get; }
    }
}