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

        public async Task<List<AmenityDTO>> GetAllAmenities()
        {
            var allAmenities = await _context.Amenities.ToListAsync();
            List<AmenityDTO> allDTOs = new List<AmenityDTO>();

            foreach (var item in allAmenities)
            {
                allDTOs.Add(ConvertToDTO(item));
            }

            return allDTOs;
        }

        public async Task<Amenities> GetAmenitiesByID(int amenitiesID) => await _context.Amenities.FindAsync(amenitiesID);

        public async Task RemoveAmenties(int amenitiesID)
        {
            Amenities amenities = await GetAmenitiesByID(amenitiesID);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }

        private AmenityDTO ConvertToDTO(Amenities amenity)
        {
            AmenityDTO adto = new AmenityDTO()
            {
                Name = amenity.Name,
                ID = amenity.ID
            };

            return adto;
        }

        public Task UpadateAmenities(int amenitesID, Amenities amenities)
        {
            throw new NotImplementedException();
        }
    }
}
