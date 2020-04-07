using Async_Inn.Data;
using Async_Inn.Data.Models;
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
        private Async_InnDbContext _context;

        public HotelService(Async_InnDbContext context)
        {
            _context = context;

        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GetAllHotels() => await _context.Hotels.ToListAsync();

        public async Task<Hotel> GetHotelByID(int hotelID) => await _context.Hotels.FindAsync(hotelID);

        public async Task RemoveHotel(int hotelID) 
        {
            Hotel hotel = await GetHotelByID(hotelID);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

    

        public async Task UpdateHotel(int hotelID, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
