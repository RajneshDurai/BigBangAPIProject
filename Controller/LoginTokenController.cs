using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using APIProjectBigBang.Data;
using APIProjectBigBang.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace APIProjectBigBang.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginTokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly HotelContext _context;

        public LoginTokenController(IConfiguration config, HotelContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Register _userData)
        {
            if (_userData != null && _userData.UserEmail != null && _userData.Password != null && _userData.Roles != null && _userData.Roles != null)
            {
                var user = await GetUser(_userData.UserEmail, _userData.Password, _userData.Roles);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("UserId", user.UserId.ToString()),
                         new Claim("Email", user.UserEmail),
                        new Claim("Password",user.Password),
                        new Claim("Role",user.Roles)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Register> GetUser(string email, string password, string role)
        {
            return await _context.Register.FirstOrDefaultAsync(u => u.UserEmail == email && u.Password == password && u.Roles == role);
        }
    }
}
