using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProjectBigBang.Data;
using APIProjectBigBang.Model;
using APIProjectBigBang.Repository.FilteringAndBookingRepository;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace APIProjectBigBang.Controller
{
    [Authorize(Roles ="user")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserFilteringAndBookingController : ControllerBase
    {
        private readonly IUserFilteringAndBookingRepository _context;

        public UserFilteringAndBookingController(IUserFilteringAndBookingRepository context)
        {
            _context = context;
        }

        // GET: api/FilteringAndBooking
        [HttpGet("List Of Hotels")]
        public async Task<ActionResult<List<Hotel>>> GetHotels()
        {
            try
            {
                var hotels = await _context.GetHotels();
                return Ok(hotels);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }

        // GET: api/FilteringAndBooking/5
        [HttpGet]
        [Route("Location")]
        public async Task<ActionResult<List<Hotel>>> GetHotelLocation(string loc)
        {
            try
            {
                var hotels = await _context.GetHotelLocation(loc);
                return Ok(hotels);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [Route("Price")]
        public async Task<ActionResult<List<GetHotelPriceTable>>> GetHotelPrice(double price)
        {
            try
            {
                var hotels = await _context.GetHotelPrice(price);
                return Ok(hotels);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [Route("Booking")]
        public async Task<ActionResult<List<GetBookingTable>>> GetBooking(string HotelName, string RoomType)
        {
            try
            {
                var hotels = await _context.GetBooking(HotelName,RoomType);
                return Ok(hotels);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /*    // PUT: api/FilteringAndBooking/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutHotel(int id, Hotel hotel)
            {
                if (id != hotel.HotelId)
                {
                    return BadRequest();
                }

                _context.Entry(hotel).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // POST: api/FilteringAndBooking
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
            {
              if (_context.Hotels == null)
              {
                  return Problem("Entity set 'HotelContext.Hotels'  is null.");
              }
                _context.Hotels.Add(hotel);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (HotelExists(hotel.HotelId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetHotel", new { id = hotel.HotelId }, hotel);
            }

            // DELETE: api/FilteringAndBooking/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteHotel(int id)
            {
                if (_context.Hotels == null)
                {
                    return NotFound();
                }
                var hotel = await _context.Hotels.FindAsync(id);
                if (hotel == null)
                {
                    return NotFound();
                }

                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool HotelExists(int id)
            {
                return (_context.Hotels?.Any(e => e.HotelId == id)).GetValueOrDefault();
            }*/
    }
}
