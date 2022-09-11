using System;
using System.Collections.Generic;
using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class ChatRoomsService
    {
        private readonly ChatRoomsRepository _repo;
        private readonly ProfilesService _ps;

        public ChatRoomsService(ChatRoomsRepository repo, ProfilesService ps)
        {
            _repo = repo;
            _ps = ps;
        }









        // Eventually add a check if the targetData.profileId exists
        // ADD LOGIC TO ISACCEPTED LATER ONCE EVERYTHING IS CONNECTED
        internal ChatRoom CreateChatRoom(ChatRoom targetData, string id)
        {
            if (id == null)
            {
                throw new Exception("You must be logged in to message someone");
            }
            Profile profile = _ps.GetProfile(targetData.ProfileId);
            if (profile == null)
            {
                throw new Exception("this user does not exists");
            }
            targetData.ProfileName = profile.Name;
            targetData.ProfilePic = profile.Picture;
            return _repo.CreateChatRoom(targetData);
        }

        internal List<ChatRoom> GetAllChats(string id)
        {
            List<ChatRoom> chats = _repo.GetAllChats(id);
            foreach (var c in chats)
            {
                var newId = c.ProfileId;
                Profile profile = _ps.GetProfile(newId);
                c.ProfilePic = profile.Picture;
                c.ProfileName = profile.Name;


            }
            return chats;




        }
    }
}