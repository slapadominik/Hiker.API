using System;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Chat.Commands.AddChatRoomMessage
{
    public class AddChatRoomMessageCommandHandler : AsyncRequestHandler<AddChatRoomMessageCommand>
    {
        private readonly IChatRoomMessageRepository _chatRoomMessageRepository;

        public AddChatRoomMessageCommandHandler(IChatRoomMessageRepository chatRoomMessageRepository)
        {
            _chatRoomMessageRepository = chatRoomMessageRepository;
        }

        protected override Task Handle(AddChatRoomMessageCommand request, CancellationToken cancellationToken)
        {
            _chatRoomMessageRepository.Add(new ChatRoomMessage()
            {
                TripId = request.ChatRoomId,
                Content = request.Content,
                UserId = request.UserId
            });

            return Task.CompletedTask;
        }
    }
}