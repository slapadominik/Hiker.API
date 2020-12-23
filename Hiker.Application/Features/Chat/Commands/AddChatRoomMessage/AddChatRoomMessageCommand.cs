using System;
using MediatR;

namespace Hiker.Application.Features.Chat.Commands.AddChatRoomMessage
{
    public class AddChatRoomMessageCommand : IRequest
    {
        public int ChatRoomId { get; }
        public string Content { get; }
        public Guid UserId { get; }

        public AddChatRoomMessageCommand(int chatRoomId, string content, Guid userId)
        {
            ChatRoomId = chatRoomId;
            Content = content;
            UserId = userId;
        }
    }
}