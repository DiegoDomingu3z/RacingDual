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
    public class ChatsController : ControllerBase
    {
        private readonly ChatsService _cs;

        private readonly ProfilesService _ps;

        public ChatsController(ChatsService cs, ProfilesService ps)
        {
            _cs = cs;
            _ps = ps;
        }



        // NOTE ChatRoomId
        [HttpPost("{id}/user/{userId}")]
        public async Task<ActionResult<Chat>> NewChat(int id, string userId, [FromBody] Chat chatData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                chatData.ChatRoomId = id;
                chatData.CreatorId = userInfo.Id;
                chatData.UserProfileId = userId;
                Chat newChat = _cs.NewChat(id, chatData);
                Profile profile = _ps.GetProfile(chatData.UserProfileId);
                newChat.UserProfileName = profile.Name;
                newChat.Creator = userInfo;
                newChat.UserProfilePic = profile.Picture;
                return Ok(newChat);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChatById(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Chat chat = _cs.GetChatById(id, userInfo.Id);
                return Ok(chat);

            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/chatRoom")]
        public async Task<ActionResult<List<Chat>>> ChatsInChatRoom(int chatRoomId)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Chat> chats = _cs.ChatInChatRoom(chatRoomId, userInfo.Id);
                return Ok(chats);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}