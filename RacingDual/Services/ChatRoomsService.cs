using System;
using System.Collections.Generic;
using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class ChatRoomsService
    {
        private readonly ChatRoomsRepository _repo;

        public ChatRoomsService(ChatRoomsRepository repo)
        {
            _repo = repo;
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
            return _repo.GetAllChats(id);

        }
    }
}