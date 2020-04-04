using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;
using Structs;
using Utilities.Extensions;

namespace Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation
{
    public class GetTouristAttractionsNearbyQueryHandler : IRequestHandler<GetMountainsNearbyLocationQuery, List<Mountain>>
    {
        private readonly IMountainsRepository _mountainsRepository;

        public GetTouristAttractionsNearbyQueryHandler(IMountainsRepository mountainsRepository)
        {
            _mountainsRepository = mountainsRepository;
        }

        public Task<List<Mountain>> Handle(GetMountainsNearbyLocationQuery request, CancellationToken cancellationToken)
        {
            return _mountainsRepository.GetMountainsWithUpcomingTripsByRadius(
                new LatLongRadius{Latitude = request.Latitude.ToRadians(), Longitude = request.Longitude.ToRadians()}, 
                request.RadiusKilometers);
        }
    }
}