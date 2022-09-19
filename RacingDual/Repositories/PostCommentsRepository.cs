using System.Data;
using Dapper;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class PostCommentsRepository
    {
        private readonly IDbConnection _db;

        public PostCommentsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal PostComment CreateComment(PostComment commentData)
        {
            string sql = @"
            INSERT INTO postComments
            (body, createdAt, postId, creatorId)
            VALUES
            (@body, @createdAt, @postId, @creatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, commentData);
            commentData.Id = id;
            return commentData;
        }
    }
}