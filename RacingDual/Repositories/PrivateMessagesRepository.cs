using System;
using System.Data;
using RacingDual.Models;

namespace RacingDual.Repositories
{
    public class PrivateMessagesRepository
    {
        private readonly IDbConnection _db;

        public PrivateMessagesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal PrivateMessages SendMessage(PrivateMessages messageData)
        {
            throw new NotImplementedException();
        }
    }
}