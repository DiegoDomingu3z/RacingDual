namespace RacingDual.Models
{
    public class Chat
    {


        public int Id { get; set; }

        public string Body { get; set; }

        public string CreatorId { get; set; }

        public string UserProfileId { get; set; }

        public string UserProfileName { get; set; }

        public string UserProfilePic { get; set; }
        public int ChatRoomId { get; set; }

        public Profile Creator { get; set; }

    }


}