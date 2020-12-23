using System.Threading.Tasks;
using Hiker.API.DTO.HubModels;

namespace Hiker.API.Hubs.Server
{
    public interface IServerChatActions
    {
        Task SendMessage(ChatRoomMessage msg);
        Task JoinToChatRoom(int chatRoomId);
        Task LeaveChatRoom(int chatRoomId);
    }
}