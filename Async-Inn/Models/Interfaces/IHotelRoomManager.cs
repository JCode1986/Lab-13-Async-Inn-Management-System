using Async_Inn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelRoomManager
    {
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
        Task UpdateHotelRoom(int hotelRoomID, HotelRoom hotelRoom);
        Task<List<HotelRoomDTO>> GetAllHotelRooms();
        Task<HotelRoomDTO> GetHotelRoomByID(int hotelRoomID);
        Task<HotelRoom> RemoveHotelRoom(int hotelRoomID);
    }
}
