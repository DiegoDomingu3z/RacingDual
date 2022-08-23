using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class PostsService
    {

        private readonly PostsRepository _repo;

        public PostsService(PostsRepository repo)
        {
            _repo = repo;
        }

        internal Post Create(Post postData)
        {
            return _repo.create(postData);
        }
    }
}