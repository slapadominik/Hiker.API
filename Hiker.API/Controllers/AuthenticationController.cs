using System;
using System.Net;
using System.Threading.Tasks;
using Hiker.Application.Common.Exceptions;
using Hiker.Application.Features.Authentication.DTO;
using Hiker.Application.Features.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("login/facebook")]
        public async Task<IActionResult> RegisterUserByFacebookTokenAsync([FromBody] FacebookToken resource)
        {
            try
            {
                var userId = await _accountService.RegisterUserFromFacebookAsync(resource);
                return Created("/users", userId);
            }
            catch (RemoteEntityNotFoundException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (EntityExistsException ex)
            {
                return Conflict("Entity already exists.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}