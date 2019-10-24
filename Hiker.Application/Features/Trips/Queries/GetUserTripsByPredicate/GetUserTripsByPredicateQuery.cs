using System;
using System.Collections.Generic;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Trips.Queries.GetIncomingTripsByUserId
{
    public class GetUserTripsByPredicateQuery : IRequest<IEnumerable<Trip>>
    {
        public Guid UserId { get; }

        public Func<Trip, bool> Predicate { get; }

        public GetUserTripsByPredicateQuery(Guid userId, Func<Trip, bool> predicate)
        {
            UserId = userId;
            Predicate = predicate;
        }
    }
}