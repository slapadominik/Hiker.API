using System.Collections.Generic;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation
{
    public class GetMountainsNearbyLocationQuery : IRequest<IEnumerable<Mountain>>
    {
        public GetMountainsNearbyLocationQuery(double latitude, double longitude, double radius)
        {
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
        }

        public double Latitude { get; }
        public double Longitude { get; }
        public double Radius{ get; }
    }
}