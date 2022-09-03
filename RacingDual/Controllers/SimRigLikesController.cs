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
    public class SimRigLikesController : ControllerBase
    {
        private readonly SimRigLikesService _srl;

        public SimRigLikesController(SimRigLikesService srl)
        {
            _srl = srl;
        }


        [HttpPost("{id}")]
        public async Task<ActionResult<SimRigLike>> Like(int id, [FromBody] SimRigLike likeData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                SimRigLike like = _srl.Like(id, likeData);
                like.accountId = userInfo.Id;
                like.CreatedAt = new DateTime();
                like.Creator = userInfo;
                return Ok(like);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}