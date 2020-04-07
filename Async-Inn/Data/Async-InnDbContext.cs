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
                    Name = "Whatever",
                    StreetAddress = "188 this hotel sucks",
                    City = "seattle",
                    State = "Washington",
                    Phone = 12345
                },
                new Hotel
                {
                    ID = 2,
                    Name = "tHING",
                    StreetAddress = "1024326 YES LANE",
                    City = "seattle",
                    State = "Washington",
                    Phone = 11232
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Who",
                    StreetAddress = "22343 go away",
                    City = "seattle",
                    State = "Washington",
                    Phone = 55434
                },
                new Hotel
                {
                    ID = 4,
                    Name = "no",
                    StreetAddress = "4434 no street",
                    City = "seattle",
                    State = "Washington",
                    Phone = 4434
                },
                new Hotel
                {
                    ID = 5,
                    Name = "WHY",
                    StreetAddress = "3343 street street",
                    City = "seattle",
                    State = "Washington",
                    Phone = 00093
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
