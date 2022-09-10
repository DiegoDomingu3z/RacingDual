using System;
using System.Collections.Generic;
using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class ChatRoomsService
    {
        private readonly ChatRoomsRepository _repo;
        private readonly ProfilesRepository _rp;

        public ChatRoomsService(ChatRoomsRepository repo, ProfilesRepository rp)
        {
            _repo = repo;
            _rp = rp;
        }






        // Eventually add a check if the targetData.profileId exists
        // ADD LOGIC TO ISACCEPTED LATER ONCE EVERYTHING IS CONNECTED
        internal ChatRoom CreateChatRoom(ChatRoom targetData, string id)
        {
            if (id == null)
            {
                throw new Exception("You must be logged in to message someone");
            }
            return _repo.CreateChatRoom(targetData);
        }

        internal List<ChatRoom> GetAllChats(string id)
        {
            List<ChatRoom> chats = _repo.GetAllChats(id);
            foreach (var c in chats)
            {
                var newId = c.ProfileId;
                Profile profile = _rp.GetProfile(newId);
                c.ProfilePic = profile.Picture;
                c.ProfileName = profile.Name;


            }
            return chats;




        }
    }
}