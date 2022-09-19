using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        internal List<PostComment> GetAllComments(int postId)
        {
            string sql = @"
            SELECT
            pc.*,
            a.*
            FROM postComments pc
            JOIN accounts a ON pc.creatorId = a.id
            WHERE pc.postId = @postId
            ";
            return _db.Query<PostComment, Profile, PostComment>(sql, (comment, profile) =>
            {
                comment.Creator = profile;
                return comment;

            }, new { postId }).ToList();
        }

        internal PostComment GetById(int id)
        {
            string sql = @"
            SELECT
            pc.*,
            a.*
            FROM postComments pc
            JOIN accounts a ON pc.creatorId = a.id
            WHERE pc.id = @id";
            return _db.Query<PostComment, Profile, PostComment>(sql, (comment, profile) =>
            {
                comment.Creator = profile;
                return comment;
            }, new { id }).FirstOrDefault();

        }

        internal PostComment EditComment(int id, PostComment original)
        {
            string sql = @"
           UPDATE postComments
           SET
           body = @Body
           WHERE id = @id";
            _db.Execute(sql, original);
            return original;
        }

        internal void RemoveComment(int id)
        {
            string sql = @"
            DELETE FROM postComments
            WHERE id = @id ";
            _db.ExecuteScalar(sql, new { id });
        }
    }
}