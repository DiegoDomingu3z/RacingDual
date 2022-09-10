using System;

namespace RacingDual.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool? IsAccepted { get; set; } = true;

        public string AccountId { get; set; }

        public string ProfileId { get; set; }

        public Profile MyAccount { get; set; }

        public string ProfileName { get; set; }

        public string ProfilePic { get; set; }
    }

    public class ChatViewModel : ChatRoom
    {
        public int ChatRoomId { get; set; }
    }


}