using APIProjectBigBang.Authorization;
using APIProjectBigBang.Repository.RegisterRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace APIProjectBigBang.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _context;

        public RegisterController(IRegisterRepository context)
        {
            _context = context;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Register>> PostUser(Register user)
        {
            return await _context.PostUser(user);
        }

      
    }
}
