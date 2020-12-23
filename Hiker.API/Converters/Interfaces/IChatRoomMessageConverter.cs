using Hiker.API.DTO.Resource.Query;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters.Interfaces
{
    public interface IChatRoomMessageConverter
    {
        ChatRoomMessageResource Convert(ChatRoomMessage msg);
    }
}