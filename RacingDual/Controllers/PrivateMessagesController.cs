using System;
using System.Collections.Generic;
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
    public class PrivateMessagesController : ControllerBase
    {
        private readonly PrivateMessagesService _pms;

        public PrivateMessagesController(PrivateMessagesService pms)
        {
            _pms = pms;
        }





        [HttpPost("{id}/profileMessages")]
        public async Task<ActionResult<PrivateMessages>> SendMessage(int profileId, [FromBody] PrivateMessages messageData)
        {

            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                messageData.CreatorId = userInfo.Id;
                messageData.CreatedAt = new DateTime();
                messageData.isPrivate = true;
                PrivateMessages message = _pms.SendMessage(profileId, userInfo.Id, messageData);
                message.Creator = userInfo;
                return Ok(message);


            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateMessages>> GetMessageById(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                PrivateMessages message = _pms.GetMessageById(id, userInfo.Id);
                return Ok(message);

            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/profileMessages")]

        public async Task<ActionResult<List<PrivateMessages>>> MessagesWithUser(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<PrivateMessages> messages = _pms.MessageWithUser(id, userInfo.Id);
                return Ok(messages);


            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}