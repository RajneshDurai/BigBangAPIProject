using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProjectBigBang.Model;
using APIProjectBigBang.Repository.RoomsCRUDRepository;
using Microsoft.AspNetCore.Authorization;

namespace APIProjectBigBang.Controller
{
    [Authorize(Roles ="admin")]  
    [Route("api/[controller]")]
    [ApiController]
    public class HotelCRUDController : ControllerBase
    {
        private readonly IHotelCRUDRepository _context;

        public HotelCRUDController(IHotelCRUDRepository context)
        {
            _context = context;
        }

        // GET: api/RoomsCRUD
        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetRooms()
        {
            try
            {
                var item = await _context.GetRooms();

                return Ok(item);
            }
           catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/RoomsCRUD/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetRoom(int id)
        {
            try
            {
                var item = await _context.GetRoom(id);

                return Ok(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/RoomsCRUD/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Hotel>>> PutRoom(int id, Hotel hotel)
        {
            try
            {
                var obj = await _context.PutRoom(id, hotel);
                return Ok(obj);
            }
           catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/RoomsCRUD
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Hotel>>> PostRoom(Hotel hotel)
        {
            try
            {
                var total = await _context.PostRoom(hotel);
                return Ok(total);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/RoomsCRUD/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hotel>>> DeleteRoom(int id)
        {
            try
            {
                var total = await _context.DeleteRoom(id);
                return Ok(total);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

   
    }
}
