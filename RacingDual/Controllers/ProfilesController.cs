using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Mvc;
using RacingDual.Models;
using RacingDual.Services;

namespace RacingDual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _ps;

        public ProfilesController(ProfilesService ps)
        {
            _ps = ps;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Profile>>> GetAllProfiles()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Profile> profiles = _ps.GetAllProfiles();
                return Ok(profiles);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(string id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Profile profile = _ps.GetProfile(id);
                return profile;
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}