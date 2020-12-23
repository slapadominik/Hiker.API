using System.Collections.Generic;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Chat.Queries.GetChatRoomMessages
{
    public class GetChatRoomMessagesQuery : IRequest<IEnumerable<ChatRoomMessage>>
    {
        public int ChatRoomId { get; }

        public GetChatRoomMessagesQuery(int chatRoomId)
        {
            ChatRoomId = chatRoomId;
        }
    }
}