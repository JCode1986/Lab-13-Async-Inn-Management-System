using Async_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; } 
        public string City { get; set; }
        public string State { get; set; }
        public int Phone { get; set; }

        // Navigation property
        public List<HotelRoom> HotelRooms { get; set; }
    }
}
