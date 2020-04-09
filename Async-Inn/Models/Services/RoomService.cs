using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class RoomService : IRoomManager
    {
        private Async_InnDbContext _context;

        public RoomService(Async_InnDbContext context)
        {
            _context = context;

        }
        public async Task<Room> CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public Task<List<Room>> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public async Task<Room> GetRoomByID(int roomID)
        {
            Room room = await _context.Rooms.FindAsync(roomID);
            return room;
        }

        public async Task RemoveRoom(int roomID)
        {
            Room room = await GetRoomByID(roomID);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoom(int roomID, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

      /*  public async Task<List<Amenities>> GetAmenities(int roomID)
        {
            var Amenities =  _context.RoomAmenities.Where(x => x.RoomID == roomID);
            return null;
        }*/
    }
}
