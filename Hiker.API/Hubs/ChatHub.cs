using System;
using System.Threading.Tasks;
using Hiker.API.DTO.HubModels;
using Hiker.API.Hubs.Client;
using Hiker.API.Hubs.Server;
using Hiker.Application.Features.Chat.Commands.AddChatRoomMessage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Hiker.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub<IClientChatActions>, IServerChatActions
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override Task OnConnectedAsync()
        {
            var userId = Context.User?.Identity?.Name;
            Console.WriteLine($"connected: {userId}");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.User?.Identity?.Name;
            Console.WriteLine($"disconnected: {userId}");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(ChatRoomMessage msg)
        {
            var userId = Context.User?.Identity?.Name;
            await _mediator.Send(new AddChatRoomMessageCommand(msg.ChatRoomId, msg.Content, Guid.Parse(userId)));
            await Clients.Groups(msg.ChatRoomId.ToString()).MessageAdded(msg);
        }

        public async Task JoinToChatRoom(int chatRoomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId.ToString());
        }

        public async Task LeaveChatRoom(int chatRoomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId.ToString());

        }
    }
}