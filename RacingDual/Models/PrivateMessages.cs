using System;

namespace RacingDual.Models
{
    public class PrivateMessages
    {
        public int Id { get; set; }

        public Profile Creator { get; set; }

        public string CreatorId { get; set; }

        public string ProfileId { get; set; }

        public string Body { get; set; }

        public string Img { get; set; }

        public bool? isPrivate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime updatedAt { get; set; }
    }
}