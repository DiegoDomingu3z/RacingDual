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



        internal Post GetById(int id)
        {
            return _repo.GetById(id);
        }
        internal PostLike PostLike(string userId, PostLike postLikeData, int postId)
        {
            Post found = _ps.GetById(postId);
            _repo.like(found, postId);
            return _repo.PostLike(postLikeData);
        }

        internal PostLike DeleteLike(int id1, string id2)
        {
            Post found =
        }


    }
}