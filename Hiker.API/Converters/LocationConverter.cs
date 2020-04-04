using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Utilities.Extensions;

namespace Hiker.API.Converters
{
    public class LocationConverter : ILocationConverter
    {
        public LocationResource Convert(float latitudeRadians, float longitudeRadians, string regionName)
        {
            return new LocationResource{
                Latitude = latitudeRadians.ToDegrees(),
                Longitude = longitudeRadians.ToDegrees(),
                RegionName = regionName

            };
        }
    }
}