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
    public class PostsController : ControllerBase
    {

        private readonly PostsService _ps;

        private readonly PostCommentsService _pcs;

        public PostsController(PostsService ps, PostCommentsService pcs)
        {
            _ps = ps;
            _pcs = pcs;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Post> post = _ps.GetAll();
                return Ok(post);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Post post = _ps.GetById(id);
                return Ok(post);

            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
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


        [HttpPost("{id}/comments")]
        [Authorize]

        public async Task<ActionResult<PostComment>> CreateComment(int id, [FromBody] PostComment commentData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                commentData.CreatedAt = new DateTime();
                commentData.CreatorId = userInfo.Id;
                PostComment newComment = _pcs.CreateComment(commentData, userInfo.Id, id);
                newComment.Creator = userInfo;
                return Ok(newComment);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Post>> Edit(int id, [FromBody] Post postData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Post post = _ps.Edit(id, userInfo.Id, postData);
                return Ok(post);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // [HttpPut("{id}/likes")]
        // [Authorize]

        // public async Task<ActionResult<Post>> Like(int id, [FromBody] Post postData)
        // {
        //     try
        //     {
        //         Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        //         Post post = _ps.like(id, userInfo.Id, postData);
        //         return Ok(post);
        //     }
        //     catch (System.Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Post post = _ps.Delete(id, userInfo.Id);
                return Ok("Deleted");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }





    }
}