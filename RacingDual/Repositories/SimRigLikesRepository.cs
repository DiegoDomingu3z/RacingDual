using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        internal SimRigLike GetById(int id)
        {
            string sql = @"
            SELECT 
            srl.*,
            a.*
            FROM simRigLikes srl
            JOIN accounts a ON srl.accountId = a.id
            WHERE srl.id = @id";
            return _db.Query<SimRigLike, Profile, SimRigLike>(sql, (simRigLike, profile) =>
            {
                simRigLike.Creator = profile;
                return simRigLike;
            }, new { id }).FirstOrDefault();
        }

        internal List<SimRigLikeViewModel> GetAllLikes(int id)
        {
            string sql = @"
            SELECT
            srl.*,
            sr.id AS SimRigId,
            a.*
            FROM simRigLikes srl
            JOIN simRigs sr ON srl.simRigId = sr.id
            JOIN accounts a ON srl.accountId = a.id
            WHERE sr.id = @id;";
            return _db.Query<SimRigLikeViewModel, Profile, SimRigLikeViewModel>(sql, (simRig, profile) =>
            {
                simRig.AccountId = profile.Id;
                simRig.ProfileName = profile.Name;
                return simRig;
            }, new { id }).ToList();
        }

        internal void DeleteLike(int id)
        {
            string sql = @"
            DELETE from simRigLikes
            WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}