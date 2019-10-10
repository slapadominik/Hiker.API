using System;
using System.Net;
using System.Threading.Tasks;
using Hiker.Application.Common.Exceptions;
using Hiker.Application.Features.Authentication.DTO;
using Hiker.Application.Features.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hiker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAccountService accountService, ILogger<AuthenticationController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost]
        [Route("register/facebook")]
        public async Task<IActionResult> RegisterUserByFacebookTokenAsync([FromBody] FacebookToken facebookToken)
        {
            try
            {
                var userId = await _accountService.RegisterUserFromFacebookAsync(facebookToken);
                return Created("/users", userId);
            }
            catch (RemoteEntityNotFoundException ex)  
            {
                _logger.LogInformation(ex.Message);
                return Unauthorized(ex.Message);
            }
            catch (EntityExistsException ex)
            {
                _logger.LogInformation(ex.Message);
                return Conflict("Entity already exists.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}