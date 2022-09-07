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
                PrivateMessages message = _pms.SendMessage(profileId, userInfo.Id, messageData);
                message.Creator = userInfo;
                message.CreatorId = userInfo.Id;
                message.ProfileId = profileId.ToString();
                message.CreatedAt = new DateTime();
                return Ok(message);


            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}