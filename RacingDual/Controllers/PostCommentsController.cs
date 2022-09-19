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
    public class PostCommentsController : ControllerBase
    {
        private readonly PostCommentsService _pcs;

        public PostCommentsController(PostCommentsService pcs)
        {
            _pcs = pcs;
        }

        [HttpGet("{postId}/post")]
        public async Task<ActionResult<List<PostComment>>> GetAllComments(int postId)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<PostComment> comments = _pcs.GetAllComments(postId);
                return Ok(comments);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PostComment>> GetById(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                PostComment comment = _pcs.GetById(id, userInfo.Id);
                return Ok(comment);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }



    }
}