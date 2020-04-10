using Async_Inn.Data.Models;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data
{
    public class Async_InnDbContext : DbContext
    {
        public Async_InnDbContext(DbContextOptions<Async_InnDbContext> options) : 
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelID, x.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(x => new { x.AmenitiesID, x.RoomID });

            //seed data

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Hotel1",
                    StreetAddress = "188 Amazing Lane",
                    City = "Seattle",
                    State = "Washington",
                    Phone = 123456789
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Hotel2",
                    StreetAddress = "1024326 Yes Lane",
                    City = "Seattle",
                    State = "Washington",
                    Phone = 987654321
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Hotel3",
                    StreetAddress = "22343 Leaf Drive",
                    City = "Seattle",
                    State = "Washington",
                    Phone = 187654329
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Hotel4",
                    StreetAddress = "4434 No Street",
                    City = "Seattle",
                    State = "Washington",
                    Phone = 176954328
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Hotel5",
                    StreetAddress = "3343 Street MCgee",
                    City = "Seattle",
                    State = "Washington",
                    Phone = 769815432
                });

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "things",
                    Layout = Layout.Studio
                },              
                new Room
                {
                    ID = 2,
                    Name = "things",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 3,
                    Name = "things",
                    Layout = Layout.Studio
                },                       
                new Room
                {
                    ID = 4,
                    Name = "things",
                    Layout = Layout.Studio
                },                       
                new Room
                {
                    ID = 5,
                    Name = "things",
                    Layout = Layout.Studio
                },                               
                new Room
                {
                    ID = 6,
                    Name = "things",
                    Layout = Layout.Studio
                });

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "cake"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "phone"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "TV"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Coffee maker"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "bed"
                }); 
        }
                 
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
