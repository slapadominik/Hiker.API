using System;
using System.Threading.Tasks;
using Hiker.API.Converters.Interfaces;
using Hiker.Application.Features.Users.Queries.GetUser;
using Hiker.Persistence.DAO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hiker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserConverter _userConverter;

        public UsersController(
            IMediator mediator, 
            IUserConverter userConverter)
        {
            _mediator = mediator;
            _userConverter = userConverter;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string facebookId, [FromQuery] Guid? userSystemId)
        {
            try
            {
                User user = null;
                if (facebookId == null)
                {
                    user = await _mediator.Send(new GetUserQuery(x => x.Id == userSystemId));
                }
                else if (userSystemId == null)
                {
                    user = await _mediator.Send(new GetUserQuery(x => x.FacebookId == facebookId));
                }

                if (user == null)
                {
                    return NotFound();
                }
                return Ok(_userConverter.Convert(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}