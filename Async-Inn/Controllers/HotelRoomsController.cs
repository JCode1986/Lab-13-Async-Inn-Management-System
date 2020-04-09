using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoomManager _hotelroom;

        public HotelRoomsController(IHotelRoomManager hotelroom)
        {
            _hotelroom = hotelroom;
        }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms() => await _hotelroom.GetAllHotelRooms();

        // GET: api/HotelRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int id)
        {
            var hotelRoom = await _hotelroom.GetHotelRoomByID(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelID)
            {
                return BadRequest();
            }

            await _hotelroom.UpdateHotelRoom(id, hotelRoom);

            return NoContent();
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            var result = await _hotelroom.CreateHotelRoom(hotelRoom);
            return CreatedAtAction("GetHotelRoom", new { id = result.HotelID }, result);
        }

        // DELETE: api/HotelRooms/5
/*        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int id)
        {
            var hotelRoom = await _hotelroom.HotelRooms.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            _hotelroom.HotelRooms.Remove(hotelRoom);
            await _hotelroom.SaveChangesAsync();

            return hotelRoom;
        }*/

    }
}
