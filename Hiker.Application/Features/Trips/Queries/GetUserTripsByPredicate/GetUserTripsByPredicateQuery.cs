using System;
using System.Collections.Generic;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Trips.Queries.GetIncomingTripsByUserId
{
    public class GetUserTripsByPredicateQuery : IRequest<IEnumerable<Trip>>
    {

        public Func<Trip, bool> Predicate { get; }

        public GetUserTripsByPredicateQuery(Func<Trip, bool> predicate)
        {
            Predicate = predicate;
        }
    }
}