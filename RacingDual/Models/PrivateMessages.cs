namespace RacingDual.Models
{
    public class PrivateMessages
    {
        public int Id { get; set; }

        public Profile Creator { get; set; }

        public int CreatorId { get; set; }

        public string ProfileId { get; set; }

        public string Body { get; set; }

        public string Img { get; set; }
    }
}