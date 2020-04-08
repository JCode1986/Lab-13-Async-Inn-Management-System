using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelRoomManager
    {
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelroom);
        Task UpdateHotelRoom(int hotelroomID, HotelRoom hotelroom);
        Task<List<HotelRoom>> GetAllHotelRooms();
        Task<HotelRoom> GetHotelRoomByID(int hotelroomID);
        Task RemoveHotelRoom(int hotelroomID);

    }
}
