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
    public class PostLikesController : ControllerBase
    {
        private readonly PostLikesService _pls;

        public PostLikesController(PostLikesService pls)
        {
            _pls = pls;
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<PostLike>> GetById(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Post post = _pls.GetById(id);
                return Ok(post);

            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost("{id}")]

        public async Task<ActionResult<PostLike>> postLike(int id, [FromBody] PostLike postLikeData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                PostLike post = _pls.PostLike(userInfo.Id, postLikeData, id);
                post.AccountId = userInfo.Id;
                post.Creator = userInfo;
                post.CreatedAt = new DateTime();

                return Ok(post);

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

        }



        [HttpDelete("{id}")]

        public async Task<ActionResult<PostLike>> DeleteLike(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                PostLike post = _pls.DeleteLike(id, userInfo.Id);
                return Ok("deleted like");

            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}