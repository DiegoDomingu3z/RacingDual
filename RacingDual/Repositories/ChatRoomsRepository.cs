using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class ChatRoomsRepository
    {
        private readonly IDbConnection _db;

        public ChatRoomsRepository(IDbConnection db)
        {
            _db = db;
        }



        internal ChatRoom CreateChatRoom(ChatRoom targetData)
        {
            string sql = @"
            INSERT into chatRooms
            (isAccepted, accountId, profileId)
            VALUES
            (@isAccepted, @accountId, @profileId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, targetData);
            targetData.Id = id;
            return targetData;
        }

        internal List<ChatRoom> GetAllChats(string id)
        {
            string sql = @"
            SELECT 
            c.*,
            a.*
            FROM chatRooms c
            JOIN accounts a ON c.accountId = a.id
            WHERE c.accountId = @id";
            return _db.Query<ChatRoom, Profile, ChatRoom>(sql, (chatRoom, prof) =>
            {
                chatRoom.MyAccount = prof;
                return chatRoom;

            }, new { id }).ToList();
        }

        internal ChatRoom GetChatRoom(int id)
        {
            string sql = @"
            SELECT * FROM chatRooms cr WHERE cr.id = @id";
            return _db.QueryFirstOrDefault<ChatRoom>(sql, new { id });
        }
    }
}