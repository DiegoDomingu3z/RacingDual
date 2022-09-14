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

        internal List<Chat> ChatsInChatRoom(int chatRoomId)
        {
            string sql = @"
            SELECT
            c.*,
            a.*
            FROM chats c
            JOIN accounts a ON c.creatorId = a.id
            WHERE c.chatRoomId = @chatRoomId";
            return _db.Query<Chat, Profile, Chat>(sql, (chats, profile) =>
            {
                chats.Creator = profile;
                return chats;
            }, new { chatRoomId }).ToList();
        }




        internal Chat GetChatById(int id)
        {
            string sql = @"
            SELECT
            c.*,
            a.*
            FROM chats c
            JOIN accounts a ON c.creatorId
            WHERE c.id = @id";
            return _db.Query<Chat, Profile, Chat>(sql, (chat, profile) =>
            {
                chat.Creator = profile;
                return chat;
            }, new { id }).FirstOrDefault();
        }

        internal void DeleteChat(int id)
        {
            string sql = @"
            DELETE FROM chats 
            WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}