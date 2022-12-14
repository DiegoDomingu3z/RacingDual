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


        //NOTE This might not work check tomorrow
        internal List<Chat> ChatInChatRoom(int chatRoomId, string id)
        {
            ChatRoom room = _crs.GetChatRoom(chatRoomId, id);

            if (room.AccountId != id && room.ProfileId != id)
            {
                throw new Exception("This chat room was not found"); //It does its just not theirs
            }
            List<Chat> chats = _repo.ChatsInChatRoom(chatRoomId);
            foreach (var c in chats)
            {
                c.UserProfileName = room.ProfileName;
                c.UserProfilePic = room.ProfilePic;
            }
            return chats;
        }

        internal Chat GetChatById(int id, string userId)
        {
            Chat chat = _repo.GetChatById(id);
            if (chat == null)
            {
                throw new Exception("This chat does not exist");
            }
            if (chat.CreatorId != userId)
            {
                throw new Exception("This chat does not exist");
            }
            Profile profile = _ps.GetProfile(chat.UserProfileId);
            chat.UserProfilePic = profile.Picture;
            chat.UserProfileName = profile.Name;
            return chat;
        }

        internal Chat DeleteChat(int id, string userId)
        {
            Chat chat = GetChatById(id, userId);
            _repo.DeleteChat(id);
            return chat;

        }
    }
}