using System.Data;
using System.Linq;
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
            INSERT INTO privateMessages
            (body, profileId, isPrivate, creatorId)
            VALUES
            (@body, @profileId, @isPrivate, @creatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, messageData);
            messageData.Id = id;
            return messageData;
        }

        internal PrivateMessages GetMessageById(int messageId, string userId)
        {
            string sql = @"
           SELECT 
           pm.*
           a.*
           FROM privateMessages pm
           JOIN accounts a ON pm.creatorId = a.id
           WHERE pm.id = @messageId AND pm.creatorId = userId
           ";
            return _db.Query<PrivateMessages, Profile, PrivateMessages>(sql, (pm, prof) =>
            {
                pm.Creator = prof;
                return pm;
            }, new { messageId }).FirstOrDefault();
        }
    }
}