using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Briefs;
using Hiker.Application.Common.Exceptions;
using Hiker.Application.Features.Mountains.Queries.GellMountains;
using Hiker.Application.Features.Mountains.Queries.GetMountain;
using Hiker.Application.Features.Mountains.Queries.GetMountainsNearbyLocation;
using Hiker.Application.Features.Mountains.Queries.GetThumbnail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hiker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MountainsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMountainBriefResourceConverter _mountainBriefResourceConverter;
        private readonly IMountainResourceConverter _mountainResourceConverter;

        public MountainsController(
            IMediator mediator, 
            IMountainBriefResourceConverter mountainBriefResourceConverter, IMountainResourceConverter mountainResourceConverter)
        {
            _mediator = mediator;
            _mountainBriefResourceConverter = mountainBriefResourceConverter;
            _mountainResourceConverter = mountainResourceConverter;
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
        [Route("{mountainId}")]
        public async Task<ActionResult<MountainResource>> Get([FromRoute] int mountainId)
        {
            try
            {
                var mountain = await _mediator.Send(new GetMountainQuery(mountainId));
                return Ok(_mountainResourceConverter.Convert(mountain));
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

        [HttpGet]
        [Route("{mountainId}/thumbnail")]
        public async Task<IActionResult> GetThumbnail(int mountainId)
        {
            try
            {
                var thumbnailStream = await _mediator.Send(new GetThumbnailQuery(mountainId));
                return File(thumbnailStream, "image/jpeg");
            }
            catch (RemoteEntityNotFoundException ex)
            {
                return BadRequest($"Mountain with Id {mountainId} doesn't have thumbnail.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}