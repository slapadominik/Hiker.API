﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.API.DTO.Resource.Command;
using Hiker.API.DTO.Resource.Query;
using Hiker.Application.Common.Exceptions;
using Hiker.Application.Features.Trips.Commands.AddTrip;
using Hiker.Application.Features.Trips.Commands.AddTripParticipant;
using Hiker.Application.Features.Trips.Commands.DeleteTrip;
using Hiker.Application.Features.Trips.Commands.DeleteTripParticipant;
using Hiker.Application.Features.Trips.Commands.UpdateTrip;
using Hiker.Application.Features.Trips.Queries.GetTripDetails;
using Hiker.Application.Features.Trips.Queries.GetUpcomingTripsForMountainObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AddTripCommand = Hiker.API.DTO.Resource.Command.AddTripCommand;

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
        private readonly ITripParticipantConverter _tripParticipantConverter;

        public TripsController(IMediator mediator, ITripConverter tripConverter, ITripResourceConverter tripResourceConverter, ITripBriefResourceConverter tripBriefResourceConverter, ITripParticipantConverter tripParticipantConverter)
        {
            _mediator = mediator;
            _tripConverter = tripConverter;
            _tripResourceConverter = tripResourceConverter;
            _tripBriefResourceConverter = tripBriefResourceConverter;
            _tripParticipantConverter = tripParticipantConverter;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddTrip([FromBody] AddTripCommand addTripCommand)
        {
            try
            {
                var id = await _mediator.Send(new Application.Features.Trips.Commands.AddTrip.AddTripCommand(_tripConverter.Convert(addTripCommand)));
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{tripId}")]
        public async Task<ActionResult<int>> DeleteTrip([FromRoute] int tripId)
        {
            try
            {
                await _mediator.Send(new DeleteTripCommand(tripId));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TripBriefResource>>> GetTripsBriefs([FromQuery] int tripDestinationType, [FromQuery] int? mountainId, [FromQuery] int? rockId, [FromQuery] DateTime dateFrom)
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
        public async Task<ActionResult<TripQueryResource>> GetTrip([FromRoute] int tripId)
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

        [HttpPatch("{tripId}")]
        public async Task<IActionResult> UpdateTrip([FromRoute] int tripId, [FromBody] UpdateTrip updateTrip)
        {
            try
            {
                await _mediator.Send(new UpdateTripCommand(_tripConverter.Convert(tripId, updateTrip)));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{tripId}/tripParticipants")]
        public async Task<IActionResult> DeleteParticipant([FromRoute] int tripId, [FromQuery] Guid userId)
        {
            try
            {
                await _mediator.Send(
                    new DeleteTripParticipantCommand(
                        _tripParticipantConverter.Convert(userId, tripId)));
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{tripId}/tripParticipants")]
        public async Task<IActionResult> AddParticipant([FromRoute] int tripId, [FromBody] TripParticipantCommandResource tripParticipantResource)
        {
            try
            {
                await _mediator.Send(
                    new AddTripParticipantCommand(
                        _tripParticipantConverter.Convert(tripParticipantResource.UserId, tripId)));
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
            catch (UniqueConstraintViolatedException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}