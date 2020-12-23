using System;
using System.Net;
using System.Threading.Tasks;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource.Input;
using Hiker.API.DTO.Resource.Query;
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
        private readonly IUserConverter _userConverter;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(
            IAccountService accountService, 
            ILogger<AuthenticationController> logger,
            IUserConverter userConverter)
        {
            _accountService = accountService;
            _logger = logger;
            _userConverter = userConverter;
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

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginInput input)
        {
            try
            {
                var response = await _accountService.LoginAsync(new LoginQuery(input.FacebookToken));
                return Ok(new LoginQueryResource
                {
                    Token = response.Token,
                    User = _userConverter.Convert(response.User)
                });
            }
            catch (RemoteEntityNotFoundException ex)
            {
                _logger.LogInformation(ex.Message);
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}