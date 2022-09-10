using System.Collections.Generic;
using RacingDual.Models;
using RacingDual.Repositories;

namespace RacingDual.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _repo;

        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }

        internal List<Profile> GetAllProfiles()
        {
            return _repo.GetAllProfiles();
        }

        internal Profile GetProfile(string id)
        {
            return _repo.GetProfile(id);
        }
    }
}