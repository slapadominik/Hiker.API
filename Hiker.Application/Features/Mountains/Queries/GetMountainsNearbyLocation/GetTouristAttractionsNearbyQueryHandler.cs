using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation
{
    public class GetTouristAttractionsNearbyQueryHandler : IRequestHandler<GetMountainsNearbyLocationQuery, IEnumerable<Mountain>>
    {
        public Task<IEnumerable<Mountain>> Handle(GetMountainsNearbyLocationQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult<IEnumerable<Mountain>>(new List<Mountain> {new Mountain {Id = 2}});
        }
    }
}