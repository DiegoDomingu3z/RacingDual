using System;

namespace RacingDual.Models
{
    public class SimRig
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public Profile Creator { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Console { get; set; }

        public string Chassis { get; set; }

        public string MonitorStand { get; set; }

        public string Pedal { get; set; }

        public string Software { get; set; }

        public string Extras { get; set; }
    }
}