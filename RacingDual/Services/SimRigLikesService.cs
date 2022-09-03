using System;
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

        internal SimRigLike GetById(int id)
        {
            SimRigLike like = _repo.GetById(id);
            if (like == null)
            {
                throw new Exception("Invalid Id");
            }
            return like;


        }

        internal SimRigLike DeleteLike(int id, object userId)
        {
            throw new NotImplementedException();
        }


    }
}