using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Application.Features.Mountains.Queries.GellMountains;
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
        private readonly IMapper _mapper;
        private readonly IMountainBriefResourceConverter _mountainBriefResourceConverter;

        public MountainsController(IMediator mediator, IMountainBriefResourceConverter mountainBriefResourceConverter)
        {
            _mediator = mediator;
            _mountainBriefResourceConverter = mountainBriefResourceConverter;
        }

        [HttpGet("location")]
        public async Task<ActionResult<IEnumerable<MountainResource>>> GetManyNearbyLocation([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] double radius)
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MountainBriefResource>>> GetAllBrief()
        {
            try
            {
                var mountains = await _mediator.Send(new GetMountainsQuery());
                return Ok(mountains.Select(x => _mountainBriefResourceConverter.Convert(x)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}