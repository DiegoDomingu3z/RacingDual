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

        internal SimRig CreateRig(SimRig simRigData)
        {
            return _repo.createRig(simRigData);
        }

    }
}