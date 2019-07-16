using System;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Hotel.Authorization.Roles;
using Hotel.Authorization.Users;
using Hotel.Guests;
using Hotel.MultiTenancy;
using Hotel.Reservations;
using Hotel.Rooms;

namespace Hotel.EntityFrameworkCore
{
    public class HotelDbContext : AbpZeroDbContext<Tenant, Role, User, HotelDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options)
            : base(options)
        {
        }
    }
}
