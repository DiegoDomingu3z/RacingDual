using System.Data;
using Dapper;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class SimRigLikesRepository
    {

        private readonly IDbConnection _db;

        public SimRigLikesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal SimRigLike Like(SimRigLike likeData)
        {
            string sql = @"
            INSERT INTO simRigLikes
            (accountId, simRigId)
            VALUES
            (@accountId, @simRigId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, likeData);
            likeData.Id = id;
            return likeData;

        }
    }
}