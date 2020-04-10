using Async_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.DTO
{
    public class AmenityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation property
        public List<RoomAmenities> RoomAmenities { get; set; }
    }
}
