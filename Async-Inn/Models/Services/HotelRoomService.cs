using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class HotelRoomService : IHotelRoomManager
    {
        private Async_InnDbContext _context;

        public HotelRoomService(Async_InnDbContext context)
        {
            _context = context;

        }
        public async Task<HotelRoom> CreateHotelRoom(HotelRoom hotelroom)
        {
            _context.HotelRooms.Add(hotelroom);
            await _context.SaveChangesAsync();
            return hotelroom;
        }

        public async Task<List<HotelRoom>> GetAllHotelRooms() => await _context.HotelRooms.ToListAsync();

        public async Task<HotelRoom> GetHotelRoomByID(int hotelroomID)
        {
            HotelRoom hotelroom = await GetHotelRoomByID(hotelroomID);
            return hotelroom;
        }

        public Task RemoveHotelRoom(int hotelroomID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateHotelRoom(int hotelroomID, HotelRoom hotelroom)
        {
            _context.Entry(hotelroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
