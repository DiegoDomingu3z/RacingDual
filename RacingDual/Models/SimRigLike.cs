using System;

namespace RacingDual.Models
{
    public class SimRigLike
    {
        public int Id { get; set; }

        public Profile Creator { get; set; }

        public int SimRigId { get; set; }

        public string accountId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}