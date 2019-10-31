using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.Application.Features.Trips.Commands.AddTrip;
using Hiker.Application.Features.Trips.Queries.GetTripDetails;
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

        public TripsController(IMediator mediator, ITripConverter tripConverter, ITripResourceConverter tripResourceConverter)
        {
            _mediator = mediator;
            _tripConverter = tripConverter;
            _tripResourceConverter = tripResourceConverter;
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