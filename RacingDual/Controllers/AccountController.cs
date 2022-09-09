using System;
using System.Threading.Tasks;
using RacingDual.Models;
using RacingDual.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RacingDual.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        private readonly PrivateMessagesService _pms;

        public AccountController(AccountService accountService, PrivateMessagesService pms)
        {
            _accountService = accountService;
            _pms = pms;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }

}