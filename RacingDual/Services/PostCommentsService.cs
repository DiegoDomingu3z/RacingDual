using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class PostCommentsService
    {
        private readonly PostCommentsRepository _repo;

        public PostCommentsService(PostCommentsRepository repo)
        {
            _repo = repo;
        }
    }
}