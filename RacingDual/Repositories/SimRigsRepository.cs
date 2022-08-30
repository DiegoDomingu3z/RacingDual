using System.Data;
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

        internal SimRig createRig(SimRig simRigData)
        {
            string sql = @"
            INSERT into simRigs
            (simType, console, chassis, monitorStand, pedal, software, extras, steeringWheel, creatorId)
            VALUES
            (@simType, @console, @chassis, @monitorStand, @pedal, @software, @extras, @steeringWheel, @creatorId);
            SELECT LAST_INSERT_ID;";
            int id = _db.ExecuteScalar<int>(sql, simRigData);
            simRigData.Id = id;
            return simRigData;

        }
    }
}