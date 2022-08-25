using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class PostLikesService
    {

        private readonly PostLikesRepository _repo;

        private readonly PostsService _ps;

        public PostLikesService(PostLikesRepository repo, PostsService ps)
        {
            _repo = repo;
            _ps = ps;
        }

        internal PostLike PostLike(string userId, PostLike postLikeData, int postId)
        {
            Post found = _ps.GetById(postId);
            _repo.like(found, postId);
            return _repo.PostLike(postLikeData);
        }
    }
}