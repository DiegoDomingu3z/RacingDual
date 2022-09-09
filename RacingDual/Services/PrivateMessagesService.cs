using System;
using System.Collections.Generic;
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

        internal PrivateMessages GetMessageById(int messageId, string userId)
        {
            PrivateMessages foundMessage = _repo.GetMessageById(messageId, userId);

            if (foundMessage.CreatorId != userId && foundMessage.ProfileId != userId)
            {
                throw new Exception("This message does not exist"); //It does I just don't want someone to know something exists there
            }
            if (foundMessage == null)
            {
                throw new Exception("This message does not exist");
            }
            return foundMessage;
        }

        internal List<PrivateMessages> MessageWithUser(int userChatId, string userId)
        {

            return _repo.MessageWithUser(userChatId);
        }
    }
}