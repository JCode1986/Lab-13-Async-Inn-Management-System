using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class AmenitiesServices : IAmenitiesManager
    {
        private Async_InnDbContext _context;

        public AmenitiesServices(Async_InnDbContext context)
        {
            _context = context;

        }
        public async Task<Amenities> CreateAmenities(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task<List<Amenities>> GetAllAmentities() => await _context.Amenities.ToListAsync();

        public async Task<Amenities> GetAmenitiesByID(int amenitiesID) => await _context.Amenities.FindAsync(amenitiesID);

        public async Task RemoveAmenties(int amenitiesID)
        {
            Amenities amenities = await GetAmenitiesByID(amenitiesID);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }

        public Task UpadateAmenities(int amenitesID, Amenities amenities)
        {
            throw new NotImplementedException();
        }
    }
}
