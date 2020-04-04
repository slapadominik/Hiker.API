using System.Collections.Generic;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation
{
    public class GetMountainsNearbyLocationQuery : IRequest<List<Mountain>>
    {
        public GetMountainsNearbyLocationQuery(double latitude, double longitude, int radiusKilometers)
        {
            Latitude = latitude;
            Longitude = longitude;
            RadiusKilometers = radiusKilometers;
        }

        public double Latitude { get; }
        public double Longitude { get; }
        public int RadiusKilometers { get; }
    }
}