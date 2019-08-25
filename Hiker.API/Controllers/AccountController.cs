using System;
using System.Threading.Tasks;
using Hiker.Application.Features.Account.DTO;
using Hiker.Application.Features.Account.Services;
using Hiker.Application.Features.Account.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hiker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("login/facebook")]
        public async Task<IActionResult> FacebookLoginAsync([FromBody] FacebookLogin resource)
        {
            try
            {
                var authorizationTokens = await _accountService.FacebookLoginAsync(resource);
                return Ok(authorizationTokens);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}