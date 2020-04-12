using Async_Inn.Data.Models;
using Async_Inn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelManager 
    {
        Task<Hotel> CreateHotel(Hotel hotel);
        Task UpdateHotel(int hotelID, Hotel hotel);
        Task<List<HotelDTO>> GetAllHotels();
        Task<HotelDTO> GetHotelByID(int hotelID);
        Task<Hotel> RemoveHotel(int hotelID);

        Task<List<HotelRoom>> GetHotelRooms(int hotelID);
    }
}
