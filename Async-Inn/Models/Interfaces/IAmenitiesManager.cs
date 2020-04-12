using Async_Inn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        Task<AmenityDTO> CreateAmenities(Amenities amenities);

        Task UpadateAmenities(int amenitesID, Amenities amenities);

        Task<List<AmenityDTO>> GetAllAmenities();

        Task<AmenityDTO> GetAmenitiesByID(int amenitiesID);

        Task<Amenities> RemoveAmenties(int amenitiesID);
    }
}
