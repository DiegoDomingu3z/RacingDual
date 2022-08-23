using System.Data;
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

        internal Post create(Post postData)
        {
            string sql = @"
            INSERT INTO posts
            (description, likes, shares, creatorId)
            VALUES
            (@description, @likes, @shares, @creatorId)
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, postData);
            postData.Id = id;
            return postData;

        }
    }
}