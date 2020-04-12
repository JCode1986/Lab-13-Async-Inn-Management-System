using Async_Inn.DTO;
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
        Task<List<RoomDTO>> GetAllRooms();
        Task<RoomDTO> GetRoomByID(int roomID);
        Task RemoveRoom(int roomID);

        // get all the Amenities in RoomAmenities
        Task<List<AmenityDTO>> AmenitiesByRoomID(int ID);
    }
}
