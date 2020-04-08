using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        Task<Amenities> CreateAmenities(Amenities amenities);

        Task UpadateAmenities(int amenitesID, Amenities amenities);

        Task<List<Amenities>> GetAllAmentities();

        Task<Amenities> GetAmenitiesByID(int amenitiesID);

        Task RemoveAmenties(int amenitiesID);
    }
}
