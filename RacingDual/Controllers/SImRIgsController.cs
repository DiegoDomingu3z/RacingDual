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
    public class SimRigsController : ControllerBase
    {

        private readonly SimRigsService _srs;

        public SimRigsController(SimRigsService srs)
        {
            _srs = srs;
        }


        [HttpGet]

        public async Task<ActionResult<List<SimRig>>> GetAllRIgs()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<SimRig> rigs = _srs.GetAllRigs();
                return Ok(rigs);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SimRig>> GetById(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                SimRig rig = _srs.GetById(id);
                return Ok(rig);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
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

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<SimRig>> DeleteRig(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                SimRig deletedRig = _srs.DeleteRig(id, userInfo.Id);
                return Ok("deleted Rig");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}