using Hiker.API.DTO.Resource.Briefs;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters.Interfaces
{
    public interface IRockBriefResourceConverter
    {
        RockBriefResource Convert(Rock rock);
    }
}