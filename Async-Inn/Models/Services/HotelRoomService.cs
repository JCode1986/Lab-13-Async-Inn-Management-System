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

        public async Task<List<HotelRoomDTO>> GetAllHotelRooms()
        {
            var hotelRoom = await _context.HotelRooms.ToListAsync();

            List<HotelRoomDTO> hotelList = new List<HotelRoomDTO>();

            foreach (var hotel in hotelRoom)
            {
                hotelList.Add(ConverToDTO(hotel));
            }

            return hotelList;
        }

        public async Task<HotelRoomDTO> GetHotelRoomByID(int hotelroomID)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(hotelroomID);
            var hr = ConverToDTO(hotelRoom);
            return hr;
        }

        public async Task<HotelRoom> RemoveHotelRoom(int hotelroomID)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(hotelroomID);

            _context.Remove(hotelRoom);

            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        public async Task UpdateHotelRoom(int hotelroomID, HotelRoom hotelroom)
        {
            _context.Entry(hotelroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Converting hotel room object to DTO object
        /// </summary>
        /// <param name="hotelRoom">hotelroom object</param>
        /// <returns>hotelroom DTO object</returns>
        public HotelRoomDTO ConverToDTO(HotelRoom hotelRoom)
        {
            HotelRoomDTO adto = new HotelRoomDTO()
            {
                HotelID = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
                RoomID = hotelRoom.RoomID
            };

            return adto;
        }
    }
}
