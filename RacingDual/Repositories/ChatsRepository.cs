using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class ChatsRepository
    {
        private readonly IDbConnection _db;

        public ChatsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Chat NewChat(Chat chatData)
        {
            string sql = @"
            INSERT into chats
            (body, creatorId, userProfileId, chatRoomId)
            VALUES
            (@body, @creatorId, @userProfileId, @chatRoomId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, chatData);
            chatData.Id = id;
            return chatData;
        }

        internal List<Chat> ChatsInChatRoom(int id)
        {
            string sql = @"
            SELECT * FROM chats";
            return _db.Query<Chat>(sql, new { id }).ToList();
        }
    }
}