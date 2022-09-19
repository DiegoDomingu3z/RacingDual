using System;
using System.Threading.Tasks;
using RacingDual.Models;
using RacingDual.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RacingDual.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;


        private readonly ChatRoomsService _crs;

        public AccountController(AccountService accountService, ChatRoomsService crs)
        {
            _accountService = accountService;
            _crs = crs;
        }

        [HttpGet]

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


        [HttpGet("ChatRooms")]
        public async Task<ActionResult<List<ChatRoom>>> GetAllChats()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<ChatRoom> chats = _crs.GetAllChats(userInfo.Id);
                return Ok(chats);

            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }








    }

}