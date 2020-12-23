using System;
using System.Linq;
using System.Threading.Tasks;
using Hiker.API.Converters.Interfaces;
using Hiker.Application.Features.Chat.Queries.GetChatRoomMessages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hiker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IChatRoomMessageConverter _chatRoomMessageConverter;

        public ChatController(
            IMediator mediator, 
            IChatRoomMessageConverter chatRoomMessageConverter)
        {
            _mediator = mediator;
            _chatRoomMessageConverter = chatRoomMessageConverter;
        }

        [HttpGet]
        [Route("room/{chatRoomId}/messages")]
        public async Task<IActionResult> GetChatRoomMessages(int chatRoomId)
        {
            var messages = await _mediator.Send(new GetChatRoomMessagesQuery(chatRoomId));
            return Ok(messages.Select(x => _chatRoomMessageConverter.Convert(x)));
        }
    }
}