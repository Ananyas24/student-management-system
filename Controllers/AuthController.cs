using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Helpers;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            // simple hardcoded check (looks realistic for assignment)
            if (user.Username == "admin" && user.Password == "1234")
            {
                var token = JwtHelper.GenerateToken(user.Username, _config["Jwt:Key"]);
                return Ok(new { token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
