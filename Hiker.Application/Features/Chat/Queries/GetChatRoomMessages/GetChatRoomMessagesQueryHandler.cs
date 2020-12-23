using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Chat.Queries.GetChatRoomMessages
{
    public class GetChatRoomMessagesQueryHandler : IRequestHandler<GetChatRoomMessagesQuery, IEnumerable<ChatRoomMessage>>
    {
        private readonly IChatRoomMessageRepository _repository;

        public GetChatRoomMessagesQueryHandler(IChatRoomMessageRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<ChatRoomMessage>> Handle(GetChatRoomMessagesQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _repository.GetByChatRoomId(request.ChatRoomId));
        }
    }
}