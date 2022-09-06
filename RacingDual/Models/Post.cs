using System;

namespace RacingDual.Models
{
    public class Post
    {
        public int Id { get; set; }
        public Profile Creator { get; set; }

        public string CreatorId { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }

        public int Shares { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }

    public class PostLikeViewModel : Post
    {
        public int PostId { get; set; }

        public string AccountId { get; set; }

        public string ProfileName { get; set; }
    }
}