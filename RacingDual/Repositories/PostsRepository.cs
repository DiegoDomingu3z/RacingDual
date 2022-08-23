using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class PostsRepository
    {

        private readonly IDbConnection _db;

        public PostsRepository(IDbConnection db)
        {
            _db = db;
        }


        internal List<Post> GetAll()
        {
            string sql = @"
            SELECT 
            p.*,
            a.*
            FROM posts p
            JOIN accounts a ON p.creatorId = a.id";
            return _db.Query<Post, Profile, Post>(sql, (post, profile) =>
            {
                post.Creator = profile;
                return post;
            }).ToList();
        }

        internal Post create(Post postData)
        {
            string sql = @"
            INSERT INTO posts
            (description, likes, shares, creatorId)
            VALUES
            (@description, @likes, @shares, @creatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, postData);
            postData.Id = id;
            return postData;

        }


    }
}