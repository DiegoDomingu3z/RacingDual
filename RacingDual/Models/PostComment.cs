using System;

namespace RacingDual.Models
{
    public class PostComment
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Body { get; set; }

        public string CreatorId { get; set; }

        public Profile Creator { get; set; }

        public int PostId { get; set; }
    }
}