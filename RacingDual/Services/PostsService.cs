using System;
using System.Collections.Generic;
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


        internal List<Post> GetAll()
        {
            return _repo.GetAll();
        }

        internal Post GetById(int id)
        {
            Post found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }
        internal Post Create(Post postData)
        {
            return _repo.create(postData);
        }

        internal Post Delete(int id, string userId)
        {
            Post post = _repo.GetById(id);
            if (post.CreatorId != userId)
            {
                throw new Exception("Forbidden");
            }
            _repo.Delete(id);
            return post;
        }
    }
}