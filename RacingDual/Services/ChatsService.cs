using System;
using System.Collections.Generic;
using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class ChatsService
    {
        private readonly ChatsRepository _repo;

        private readonly ProfilesService _ps;

        private readonly ChatRoomsService _crs;

        public ChatsService(ChatsRepository repo, ProfilesService ps, ChatRoomsService crs)
        {
            _repo = repo;
            _ps = ps;
            _crs = crs;
        }

        internal Chat NewChat(int id, Chat chatData)
        {
            Profile profile = _ps.GetProfile(chatData.UserProfileId);
            if (chatData.UserProfileId != profile.Id)
            {
                throw new Exception("This user does not exists");
            }

            return _repo.NewChat(chatData);


        }

        internal List<Chat> ChatInChatRoom(int chatRoomId, string id)
        {
            ChatRoom room = _crs.GetChatRoom(chatRoomId, id);

            // CREATE getById in chatRoom and make sure you can only get it if you are the creator
        }
    }
}