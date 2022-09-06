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
    public class SimRigLikesController : ControllerBase
    {
        private readonly SimRigLikesService _srl;

        public SimRigLikesController(SimRigLikesService srl)
        {
            _srl = srl;
        }


        [HttpGet("{id}/profiles")]
        public async Task<ActionResult<List<SimRigLikeViewModel>>> GetAllLikes(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<SimRigLikeViewModel> likes = _srl.GetAllLikes(id);
                return Ok(likes);
            }
            catch (System.Exception)
            {

                throw;
            }
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


        [HttpGet("{id}")]
        public async Task<ActionResult<SimRigLike>> GetById(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                SimRigLike rigLike = _srl.GetById(id);
                return Ok(rigLike);

            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SimRigLike>> DeleteLike(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                SimRigLike deletedLike = _srl.DeleteLike(id, userInfo.Id);
                return Ok("deleted like");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}