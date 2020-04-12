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
        private Async_InnDbContext _context { get; }
        private IHotelRoomManager _hotelRoom { get; }
        public HotelService(Async_InnDbContext context, IHotelRoomManager hotelRoom)
        {
            _context = context;
            _hotelRoom = hotelRoom;
        }

        /// <summary>
        /// Method that creates a hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        /// <summary>
        /// Method that read all hotels in database; objects converted to dto
        /// </summary>
        /// <returns>hotel dto</returns>
        public async Task<List<HotelDTO>> GetAllHotels()
        {
            List<Hotel> hotel = await _context.Hotels.ToListAsync();
            List<HotelDTO> hDTO = new List<HotelDTO>();
            foreach (var item in hotel)
            {
                HotelDTO aDTO = ConvertToDTO(item);
                hDTO.Add(aDTO);
            }
            return hDTO;
        } 

        public async Task<List<HotelRoom>> GetHotelRooms(int hotelID)
        {
            var hotelrooms = await _context.HotelRooms.Where(r => r.HotelID == hotelID)
                                                    .Include(d => d.Room)
                                                    .ThenInclude(a => a.RoomAmenities)
                                                    .ThenInclude(x => x.Amenities).ToListAsync();
           List<HotelRoomDTO> hotelRooms = new List<HotelRoomDTO>();
            foreach (var room in hotelrooms)
            {
                HotelRoomDTO roomDTO = await _hotelRoom.GetHotelRoomByID(room.RoomID);
                hotelRooms.Add(roomDTO);
            }
            return hotelrooms;
        }

        /// <summary>
        /// Method that reads a specific hotel by passing in ID number
        /// </summary>
        /// <param name="hotelID"></param>
        /// <returns></returns>


        public async Task<HotelDTO> GetHotelByID(int hotelID)
        {
            Hotel hotel = new Hotel();
            HotelDTO hoteldto = new HotelDTO();
            hotel = _context.Hotels.Find(hotelID);

            hoteldto.Name = hotel.Name;
            hoteldto.Phone = hotel.Phone;
            hoteldto.City = hotel.City;

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

        public async Task<Hotel> RemoveHotel(int hotelID)
        {
            var hotel = await _context.Hotels.FindAsync(hotelID);
            _context.Remove(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task UpdateHotel(int hotelID, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Convert hotel object to DTO object
        /// </summary>
        /// <param name="hotel">hotel object</param>
        /// <returns>hotel DTO object</returns>
        public HotelDTO ConvertToDTO(Hotel hotel)
        {
            HotelDTO hDTO = new HotelDTO()
            {
                ID = hotel.ID,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };
            return hDTO;
        }

    }
}
