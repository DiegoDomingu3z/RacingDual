using System;
using System.Collections.Generic;
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

        internal List<PostComment> GetAllComments(int postId)
        {
            List<PostComment> comments = _repo.GetAllComments(postId);
            if (comments.Count == 0)
            {
                throw new Exception("this post has no comments");
            }
            return comments;
        }

        internal PostComment GetById(int id, string userId)
        {

            PostComment foundComment = _repo.GetById(id);
            if (foundComment == null)
            {
                throw new Exception("This comment does not exists");
            }
            return foundComment;
        }
    }
}