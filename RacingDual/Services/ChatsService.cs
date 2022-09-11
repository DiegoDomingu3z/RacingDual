using System;
using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class ChatsService
    {
        private readonly ChatsRepository _repo;

        private readonly ProfilesService _ps;

        public ChatsService(ChatsRepository repo, ProfilesService ps)
        {
            _repo = repo;
            _ps = ps;
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
    }
}