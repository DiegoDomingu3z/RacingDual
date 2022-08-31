using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class SimRigsRepository
    {

        private readonly IDbConnection _db;

        public SimRigsRepository(IDbConnection db)
        {
            _db = db;
        }


        internal List<SimRig> GetAllRigs()
        {
            string sql = @"
            SELECT
            sr.*,
            a.*
            FROM simRigs sr
            JOIN accounts a ON sr.creatorId = a.id";
            return _db.Query<SimRig, Profile, SimRig>(sql, (simRig, profile) =>
            {
                simRig.Creator = profile;
                return simRig;
            }).ToList();
        }

        internal SimRig GetById(int id)
        {
            string sql = @"
            SELECT
            sr.*,
            a.*
            FROM simRigs sr
            JOIN accounts a ON sr.creatorId = a.id
            WHERE sr.id = @id";
            return _db.Query<SimRig, Profile, SimRig>(sql, (simRig, profile) =>
            {
                simRig.Creator = profile;
                return simRig;
            }, new { id }).FirstOrDefault();
        }



        internal SimRig createRig(SimRig simRigData)
        {
            string sql = @"
            INSERT into simRigs
            (simType, console, chassis, monitorStand, pedal, software, extras, steeringWheel, wheelBase, creatorId)
            VALUES
            (@simType, @console, @chassis, @monitorStand, @pedal, @software, @extras, @steeringWheel, @wheelBase, @creatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, simRigData);
            simRigData.Id = id;
            return simRigData;

        }

        internal void DeleteRig(int id)
        {
            string sql = @"
           DELETE from simRigs
           WHERE id = @id";
            _db.Execute(sql, new { id });
        }


    }
}