using System;
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



        internal PostLike GetById(int id)
        {
            PostLike like = _repo.GetById(id);
            if (like == null)
            {
                throw new Exception("Invalid Id");
            }
            return like;
        }
        internal PostLike PostLike(string userId, PostLike postLikeData, int postId)
        {
            Post found = _ps.GetById(postId);
            _repo.like(found, postId);
            return _repo.PostLike(postLikeData);
        }

        internal PostLike DeleteLike(int id, string userId)
        {
            PostLike found = GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            if (found.AccountId != userId)
            {
                throw new Exception("Forbidden");
            }
            _repo.DeleteLike(id);
            return found;
        }
    }
}