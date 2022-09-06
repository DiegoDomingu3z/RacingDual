using System;
using System.ComponentModel.DataAnnotations;

namespace RacingDual.Models
{
    public class SimRig
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public Profile Creator { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        [Required]
        public string SimType { get; set; }

        public string Console { get; set; }

        public string Chassis { get; set; }

        public string MonitorStand { get; set; }

        public string SteeringWheel { get; set; }

        public string Pedal { get; set; }

        public string Software { get; set; }

        public string Extras { get; set; }

        public string WheelBase { get; set; }
    }

    public class SimRigLikeViewModel : SimRig
    {
        public int SimRigId { get; set; }

        public string accountId { get; set; }
    }
}