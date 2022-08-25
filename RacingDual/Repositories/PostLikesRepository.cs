using System.Data;
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
    }
}