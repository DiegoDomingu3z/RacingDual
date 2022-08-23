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
    public class PostsController : ControllerBase
    {

        private readonly PostsService _ps;

        public PostsController(PostsService ps)
        {
            _ps = ps;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Post>> Create([FromBody] Post postData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                postData.CreatorId = userInfo.Id;
                postData.CreatedAt = new DateTime();
                postData.UpdatedAt = new DateTime();
                Post newPost = _ps.Create(postData);
                newPost.Creator = userInfo;
                return Ok(newPost);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}