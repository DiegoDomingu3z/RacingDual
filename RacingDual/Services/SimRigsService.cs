using System;
using System.Collections.Generic;
using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class SimRigsService
    {

        private readonly SimRigsRepository _repo;

        public SimRigsService(SimRigsRepository repo)
        {
            _repo = repo;
        }

        internal List<SimRig> GetAllRigs()
        {
            return _repo.GetAllRigs();
        }

        internal SimRig CreateRig(SimRig simRigData)
        {
            return _repo.createRig(simRigData);

        }

        internal SimRig GetById(int id)
        {
            SimRig found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal SimRig DeleteRig(int id, string userId)
        {
            SimRig rig = GetById(id);
            if (rig.CreatorId != userId)
            {
                throw new Exception("Forbidden");
            }
            _repo.DeleteRig(id);
            return rig;
        }
    }
}