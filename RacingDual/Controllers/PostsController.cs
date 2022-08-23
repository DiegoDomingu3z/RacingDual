using Microsoft.AspNetCore.Mvc;
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


    }
}