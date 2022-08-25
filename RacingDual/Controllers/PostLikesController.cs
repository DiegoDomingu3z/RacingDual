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

    }
}