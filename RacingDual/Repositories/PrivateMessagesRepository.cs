using System.Data;
using Dapper;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class PrivateMessagesRepository
    {
        private readonly IDbConnection _db;

        public PrivateMessagesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal PrivateMessages SendMessage(PrivateMessages messageData)
        {
            string sql = @"
            INSERT into privateMessages
            ()
            VALUES
            ();
            SELECT LAST_INSERT_ID;";
            int id = _db.ExecuteScalar<int>(sql, messageData);
            messageData.Id = id;
            return messageData;
        }
    }
}