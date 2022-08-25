using System;

namespace RacingDual.Models
{
    public class PostLike
    {
        public int Id { get; set; }
        public string AccountId { get; set; }

        public int PostId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Profile Creator { get; set; }
    }
}