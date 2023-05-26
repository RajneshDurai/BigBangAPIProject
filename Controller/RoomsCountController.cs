using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProjectBigBang.Data;
using APIProjectBigBang.Model;
using APIProjectBigBang.Repository.RoomsCountRepository;
using Microsoft.AspNetCore.Authorization;

namespace APIProjectBigBang.Controller
{
    [Authorize(Roles ="user")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsCountController : ControllerBase
    {
        private readonly IRoomsCountRepository _context;

        public RoomsCountController(IRoomsCountRepository context)
        {
            _context = context;
        }

        // GET: api/RoomsCount
        [HttpGet("Count of Available Room in Specific Hotel")]
        public async Task<ActionResult<int>> GetCount(string HotelName)
        {
            try
            {
                var avai = await _context.GetCount(HotelName);
                return Ok(avai);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("Count of Available Room in Each Hotel")]
        public async Task<ActionResult<List<GetCountsTable>>> GetCounts()
        {
            try
            {
                var avai = await _context.GetCounts();
                return Ok(avai);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
      
    }
}
