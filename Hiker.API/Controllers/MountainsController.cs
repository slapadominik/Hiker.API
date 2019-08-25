using System.Collections.Generic;
using System.Threading.Tasks;
using Hiker.API.DTO;
using Hiker.Application.Features.TouristAttractions.Queries.GetTouristAttractionsNearby;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hiker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MountainsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MountainsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mountain>>> GetManyNearbyLocation([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] double radius)
        {
            return Ok(await _mediator.Send(new GetTouristAttractionsNearbyQuery()));
        }

    }
}