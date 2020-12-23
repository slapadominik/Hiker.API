using System.Threading.Tasks;
using Hiker.API.DTO.HubModels;

namespace Hiker.API.Hubs.Client
{
    public interface IClientChatActions
    {
        Task MessageAdded(ChatRoomMessage roomMessage);
    }
}