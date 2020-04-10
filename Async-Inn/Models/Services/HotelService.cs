using Async_Inn.Data;
using Async_Inn.Data.Models;
using Async_Inn.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class HotelService : IHotelManager

    {
        private Async_InnDbContext _context;

        public HotelService(Async_InnDbContext context)
        {
            _context = context;

        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GetAllHotels() => await _context.Hotels.ToListAsync();

        public async Task<HotelDTO> GetHotelByID(int hotelID)
        {
            Hotel hotel = new Hotel();
            HotelDTO hoteldto = new HotelDTO();
            hotel = _context.Hotels.Find(hotelID);

            hoteldto.Name = hotel.Name;
            hoteldto.Phone = hotel.Phone;
            hoteldto.City = hotel.City;
            hoteldto.ID = hotel.ID;
            hoteldto.State = hotel.State;
            hoteldto.StreetAddress = hotel.StreetAddress;

            var hotelRooms = await _context.HotelRooms.Where(r => r.HotelID == hotelID)
                                                .Include(d => d.Room)
                                                .ThenInclude(x => x.RoomAmenities)
                                                .ThenInclude(a => a.Amenities)
                                                .ToListAsync();

            List<HotelRoomDTO> room = new List<HotelRoomDTO>();

            foreach (var hr in hotelRooms)
            {

                HotelRoomDTO rm = new HotelRoomDTO();
                rm.Rate = hr.Rate;
                rm.RoomNumber = hr.RoomNumber;
                RoomDTO rdto = new RoomDTO
                {
                    Layout = hr.Room.Layout.ToString(),
                    Name = hr.Room.Name,
                };

                room.Add(rm);
            }

            hoteldto.Rooms = room;

            return hoteldto;
        }

        public async Task RemoveHotel(int hotelID)
        {
            Hotel hotel = new Hotel();
            if (hotelID == hotel.ID)
            {
            _context.Remove(hotel.ID);
            await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateHotel(int hotelID, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
