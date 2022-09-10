using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Profile> GetAllProfiles()
        {
            string sql = @"
            SELECT * FROM accounts a";
            return _db.Query<Profile>(sql).ToList();
        }

        internal Profile GetProfile(string id)
        {
            string sql = @"
            SELECT * FROM accounts a WHERE a.id = @id";
            return _db.QueryFirstOrDefault<Profile>(sql, new { id });
        }
    }
}