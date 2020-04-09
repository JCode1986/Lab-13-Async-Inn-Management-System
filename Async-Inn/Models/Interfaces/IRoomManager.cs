using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoomManager
    {
        Task<Room> CreateRoom(Room room);
        Task UpdateRoom(int roomID, Room room);
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoomByID(int roomID);
        Task RemoveRoom(int roomID);
    }
}
