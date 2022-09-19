using System;
using RacingDual.Models;
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

        internal PostComment CreateComment(PostComment commentData, string id)
        {
            if (id == null)
            {
                throw new Exception("You need to be logged in to comment");
            }
            return _repo.CreateComment(commentData);
        }
    }
}