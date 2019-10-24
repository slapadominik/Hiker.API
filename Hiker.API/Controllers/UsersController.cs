﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiker.API.Converters.Interfaces;
using Hiker.Application.Features.Trips.Queries.GetIncomingTripsByUserId;
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
        private readonly ITripBriefResourceConverter _tripBriefResourceConverter;

        public UsersController(
            IMediator mediator, 
            IUserConverter userConverter, ITripBriefResourceConverter tripBriefResourceConverter)
        {
            _mediator = mediator;
            _userConverter = userConverter;
            _tripBriefResourceConverter = tripBriefResourceConverter;
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

        [HttpGet("{userId}/trips")]
        public async Task<IActionResult> GetUserTrips([FromRoute] Guid userId, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            try
            {
                IEnumerable<Trip> trips;
                if (dateFrom.HasValue)
                {
                    trips = await _mediator.Send(new GetUserTripsByPredicateQuery(userId, x => x.DateFrom >= dateFrom));
                }
                else if (dateTo.HasValue)
                {
                    trips = await _mediator.Send(new GetUserTripsByPredicateQuery(userId, x => x.DateFrom >= dateFrom));
                }
                else
                {
                    return BadRequest("Either DateFrom or DateTo filter should be used.");
                }

                return Ok(trips.Select(x => _tripBriefResourceConverter.Convert(x)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}