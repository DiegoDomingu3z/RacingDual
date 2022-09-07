using System.Data;

namespace RacingDual.Repositories
{
    public class PostCommentsRepository
    {
        private readonly IDbConnection _db;

        public PostCommentsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}