using System;
using System.Collections.Generic;
using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class PostCommentsService
    {
        private readonly PostCommentsRepository _repo;

        private readonly PostsService _ps;

        public PostCommentsService(PostCommentsRepository repo, PostsService ps)
        {
            _repo = repo;
            _ps = ps;
        }

        internal PostComment CreateComment(PostComment commentData, string userId, int postId)
        {
            if (userId == null)
            {
                throw new Exception("You need to be logged in to comment");
            }
            Post post = _ps.GetById(postId);
            if (post == null)
            {
                throw new Exception("This post does not exists");

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

        internal PostComment EditComment(int id, string userId, PostComment commentData)
        {
            PostComment original = GetById(id, userId);
            if (original.CreatorId != userId)
            {
                throw new Exception("This is not your comment");
            }
            original.Body = commentData.Body ?? original.Body;
            _repo.EditComment(id, original);
            return original;


        }

        internal PostComment RemoveComment(int id, string userId)
        {
            PostComment removingComment = GetById(id, userId);
            if (removingComment.CreatorId != userId)
            {
                throw new Exception("Forbidden");
            }
            _repo.RemoveComment(id);
            return removingComment;
        }
    }
}