using System.Collections.Generic;
using Hiker.Persistence.DAO;

namespace Hiker.Persistence.Repositories.Interfaces
{
    public interface IChatRoomMessageRepository
    {
        IEnumerable<ChatRoomMessage> GetByChatRoomId(int chatRoomId);
        void Add(ChatRoomMessage msg);
    }
}