using Microsoft.AspNetCore.Mvc;
using RacingDual.Services;

namespace RacingDual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostCommentsController : ControllerBase
    {
        private readonly PostCommentsService _pcs;

        public PostCommentsController(PostCommentsService pcs)
        {
            _pcs = pcs;
        }
    }
}