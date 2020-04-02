using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class RoomAmenities
    {
        public int RoomID { get; set; }
        public string AmenitiesID { get; set; }

        public Room Room { get; set; }
        public Amenities Amenities { get; set; }
    }
}
