using Hotel.Rooms;

namespace Hotel.Web.Host.Models
{
    public class RoomModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public RoomStatus Status { get; set; }

        public bool AllowedSmoking { get; set; }
    }
}