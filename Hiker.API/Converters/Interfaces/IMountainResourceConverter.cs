using Hiker.API.DTO.Resource;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters.Interfaces
{
    public interface IMountainResourceConverter
    {
        MountainResource Convert(Mountain mountain);
    }
}