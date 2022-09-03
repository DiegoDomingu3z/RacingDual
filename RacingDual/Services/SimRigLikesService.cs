using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{

    public class SimRigLikesService
    {

        private readonly SimRigLikesRepository _repo;

        public SimRigLikesService(SimRigLikesRepository repo)
        {
            _repo = repo;
        }

        internal SimRigLike Like(int id, SimRigLike likeData)
        {
            return _repo.Like(likeData);
        }

    }
}