using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.DTO
{
    public class RoomDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }

        //Navigation property
        public List<AmenityDTO> Amenities { get; set; }
    }
}
