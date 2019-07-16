using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace Hotel.Rooms
{
    public class Room : Entity
    {
        [Required]
        public int Number { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public RoomStatus Status { get; set; }

        public bool AllowedSmoking { get; set; }

        public Room()
        {

        }

        public Room(int number, string name, RoomStatus status, bool allowedSmoking)
        {
            Number = number;
            Name = name;
            Status = status;
            AllowedSmoking = allowedSmoking;
        }
    }
}
