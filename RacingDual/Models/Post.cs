namespace RacingDual.Models
{
    public class Post
    {
        public int Id { get; set; }
        public Profile Creator { get; set; }

        public int CreatorId { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }

        public int Shares { get; set; }


    }
}