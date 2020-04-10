using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Room
    {
        public int ID { get; set; }

        //enum; access by Layout.Studio, etc.
        public Layout Layout { get; set; }
        public string Name { get; set; }

        //Navigation properties
        public List<RoomAmenities> RoomAmenities { get; set; }
        public List<HotelRoom> HotelRooms { get; set; }
    }

    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}
