using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hiker.API.DTO;
using Hiker.API.DTO.Resource;
using Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation;
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
            try
            {
                var mountains = await _mediator.Send(new GetMountainsNearbyLocationQuery(latitude, longitude, radius));
                return Ok(mountains);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}