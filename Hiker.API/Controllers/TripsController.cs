using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.API.DTO.Resource.Command;
using Hiker.Application.Features.Trips.Commands.AddTrip;
using Hiker.Application.Features.Trips.Queries.GetTripDetails;
using Hiker.Application.Features.Trips.Queries.GetUpcomingTripsForMountainObject;
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
        private readonly ITripResourceConverter _tripResourceConverter;
        private readonly ITripBriefResourceConverter _tripBriefResourceConverter;

        public TripsController(IMediator mediator, ITripConverter tripConverter, ITripResourceConverter tripResourceConverter, ITripBriefResourceConverter tripBriefResourceConverter)
        {
            _mediator = mediator;
            _tripConverter = tripConverter;
            _tripResourceConverter = tripResourceConverter;
            _tripBriefResourceConverter = tripBriefResourceConverter;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] TripCommandResource tripCommand)
        {
            try
            {
                var id = await _mediator.Send(new AddTripCommand(_tripConverter.Convert(tripCommand)));
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TripBriefResource>>> GetBriefs([FromQuery] int tripDestinationType, [FromQuery] int? mountainId, [FromQuery] int? rockId, [FromQuery] DateTime dateFrom)
        {
            try
            {
                var trips = await _mediator.Send(new GetUpcomingTripsForMountainObjectQuery{TripDestinationType = tripDestinationType, MountainId = mountainId, RockId = rockId, DateFrom = dateFrom});
                return Ok(trips.Select(x => _tripBriefResourceConverter.Convert(x)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<int>> Get([FromRoute] int tripId)
        {
            try
            {
                var trip = await _mediator.Send(new GetTripDetailsQuery(tripId));
                return Ok(_tripResourceConverter.Convert(trip));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}