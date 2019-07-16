using System;
using System.Linq;
using Hotel.Guests;
using Hotel.Reservations;
using Hotel.Rooms;

namespace Hotel.EntityFrameworkCore.Seed.Host
{
    public class DefaultHotelBuilder
    {
        private readonly HotelDbContext _context;

        public DefaultHotelBuilder(HotelDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            if (!_context.Guests.Any())
            {
                //GUESTS
                _context.Guests.Add(new Guest("Alper Ebicoglu", DateTime.Now.AddDays(-10)));
                _context.Guests.Add(new Guest("George Michael", DateTime.Now.AddDays(-5)));
                _context.Guests.Add(new Guest("Daft Punk", DateTime.Now.AddDays(-1)));
                _context.SaveChanges();

                //ROOMS
                _context.Rooms.Add(new Room(101, "yellow-room", RoomStatus.Available, false));
                _context.Rooms.Add(new Room(102, "blue-room", RoomStatus.Available, false));
                _context.Rooms.Add(new Room(103, "white-room", RoomStatus.Unavailable, false));
                _context.Rooms.Add(new Room(104, "black-room", RoomStatus.Unavailable, false));
                _context.SaveChanges();

                //RESERVATIONS
                _context.Reservations.Add(new Reservation(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(3), _context.Rooms.First(x => x.Name == "white-room").Id, _context.Guests.First(x => x.Name == "Alper Ebicoglu").Id));
                _context.Reservations.Add(new Reservation(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(4), _context.Rooms.First(x => x.Name == "black-room").Id, _context.Guests.First(x => x.Name == "George Michael").Id));
            }
        }
    }
}
