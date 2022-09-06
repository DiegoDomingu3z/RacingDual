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
            return _repo.SendMessage(messageData);
        }
    }
}