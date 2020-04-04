using Hiker.API.DTO.Resource;

namespace Hiker.API.Converters.Interfaces
{
    public interface ILocationConverter
    {
        LocationResource Convert(float latitudeRadians, float longitudeRadians, string regionName);
    }
}