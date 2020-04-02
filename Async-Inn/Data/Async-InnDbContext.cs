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
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
