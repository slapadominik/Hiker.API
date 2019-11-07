using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Trips.Queries.GetIncomingTripsByUserId
{
    public class GetUserTripsByPredicateQueryHandler : IRequestHandler<GetUserTripsByPredicateQuery, IEnumerable<Trip>>
    {
        private readonly ITripsRepository _tripsRepository;

        public GetUserTripsByPredicateQueryHandler(ITripsRepository tripsRepository)
        {
            _tripsRepository = tripsRepository;
        }

        public Task<IEnumerable<Trip>> Handle(GetUserTripsByPredicateQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_tripsRepository.GetByPredicate(x => request.Predicate.Invoke(x)));
        }
    }
}