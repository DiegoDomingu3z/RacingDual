using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class PostLikesRepository
    {

        private readonly IDbConnection _db;

        public PostLikesRepository(IDbConnection db)
        {
            _db = db;
        }


        internal PostLike GetById(int id)
        {
            string sql = @"
            SELECT
            pl.*,
            a.*
            FROM postLikes pl
            JOIN accounts a ON pl.accountId = a.id
            WHERE pl.id = @id";
            return _db.Query<PostLike, Profile, PostLike>(sql, (like, profile) =>
            {
                like.Creator = profile;
                return like;
            }, new { id }).FirstOrDefault();
        }

        internal List<PostLikeViewModel> GetAllLikes(int id)
        {
            string sql = @"
            SELECT 
            pl.*,
            p.id AS PostId,
            a.*
            FROM postLikes pl
            JOIN posts p ON pl.PostId = p.id
            JOIN accounts a ON pl.accountId = a.id
            WHERE p.id = @id
            ";
            return _db.Query<PostLikeViewModel, Profile, PostLikeViewModel>(sql, (postLike, profile) =>
            {
                postLike.AccountId = profile.Id;
                postLike.ProfileName = profile.Name;
                return postLike;
            }, new { id }).ToList();
        }

        internal PostLike PostLike(PostLike postLikeData)
        {
            string sql = @"
            INSERT INTO postLikes
            (accountId, postId)
            VALUES
            (@accountId, @postId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, postLikeData);
            postLikeData.Id = id;
            return postLikeData;

        }



        internal void like(Post found, int id)
        {
            string sql = @"
            UPDATE posts
            SET
            likes = @likes +1
            WHERE
            posts.id = @id";
            _db.Execute(sql, found);

        }



        internal void DeleteLike(int id)
        {
            string sql = @"
            DELETE from postLikes
            WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}