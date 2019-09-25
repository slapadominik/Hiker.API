using System;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public GetUserQuery(Func<User, bool> predicate)
        {
            Predicate = predicate;
        }

        public Func<User, bool> Predicate { get;  }
    }
}