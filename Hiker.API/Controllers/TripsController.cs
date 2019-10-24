using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.Application.Features.Trips.Commands.AddTrip;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hiker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITripConverter _tripConverter;

        public TripsController(IMediator mediator, ITripConverter tripConverter)
        {
            _mediator = mediator;
            _tripConverter = tripConverter;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] TripResource trip)
        {
            try
            {
                var id = await _mediator.Send(new AddTripCommand(_tripConverter.Convert(trip)));
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}