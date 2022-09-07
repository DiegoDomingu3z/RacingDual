using System;
using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class PrivateMessagesService
    {
        private readonly PrivateMessagesRepository _repo;

        public PrivateMessagesService(PrivateMessagesRepository repo)
        {
            _repo = repo;
        }

        internal PrivateMessages SendMessage(int profileId, string userId, PrivateMessages messageData)
        {
            if (userId == null)
            {
                throw new Exception("You need to login first");
            }
            if (profileId.ToString() == null)
            {
                throw new Exception("This user does not exits");
            }
            return _repo.SendMessage(messageData);
        }
    }
}