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
    public class SimRigsController : ControllerBase
    {

        private readonly SimRigsService _srs;

        public SimRigsController(SimRigsService srs)
        {
            _srs = srs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<SimRig>> CreateRig([FromBody] SimRig simRigData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                simRigData.CreatedAt = new DateTime();
                simRigData.UpdatedAt = new DateTime();
                simRigData.CreatorId = userInfo.Id;
                SimRig newSim = _srs.CreateRig(simRigData);
                newSim.Creator = userInfo;
                return Ok(newSim);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}