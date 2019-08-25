using MediatR;

namespace Hiker.Application.Features.TouristAttractions.Queries.GetTouristAttractionsNearby
{
    public class GetTouristAttractionsNearbyQuery : IRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius{ get; set; }
    }
}