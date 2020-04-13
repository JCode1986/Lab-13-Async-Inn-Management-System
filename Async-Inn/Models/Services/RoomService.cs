using Async_Inn.Data;
using Async_Inn.DTO;
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

        public Task<List<RoomDTO>> GetAllRooms()
        {
            throw new NotImplementedException();
        }
        public Task<RoomDTO> GetRoomByID(int roomID)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRoom(int roomID)
        {
            throw new NotImplementedException();
        }

        public Task<List<AmenityDTO>> AmenitiesByRoomID(int ID)
        {
            throw new NotImplementedException();
        }


        public async Task UpdateRoom(int roomID, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public RoomDTO ConverToDTO(Room room)
        {
            RoomDTO rdto = new RoomDTO()
            {
                ID = room.ID,
                Name = room.Name,
                Layout = room.Layout.ToString()
            };
            return rdto;
        }
    }
}
