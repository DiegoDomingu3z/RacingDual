using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RacingDual.Models;
using RacingDual.Services;

namespace RacingDual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ChatRoomsController : ControllerBase
    {
        private readonly ChatRoomsService _crs;

        public ChatRoomsController(ChatRoomsService crs)
        {
            _crs = crs;
        }



        [HttpPost]
        public async Task<ActionResult<ChatRoom>> CreateChatRoom([FromBody] ChatRoom targetData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                targetData.CreatedAt = new DateTime();
                targetData.AccountId = userInfo.Id;
                ChatRoom target = _crs.CreateChatRoom(targetData, userInfo.Id);
                target.MyAccount = userInfo;
                return Ok(target);


            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatRoom>> GetChatRoom(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                ChatRoom room = _crs.GetChatRoom(id, userInfo.Id);
                room.MyAccount = userInfo;
                return Ok(room);

            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}