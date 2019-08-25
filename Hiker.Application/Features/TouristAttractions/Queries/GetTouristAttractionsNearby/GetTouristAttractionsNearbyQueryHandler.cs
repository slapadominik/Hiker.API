using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Hiker.Application.Features.TouristAttractions.Queries.GetTouristAttractionsNearby
{
    public class GetTouristAttractionsNearbyQueryHandler : IRequestHandler<GetTouristAttractionsNearbyQuery, Unit>
    {
        public Task<Unit> Handle(GetTouristAttractionsNearbyQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}