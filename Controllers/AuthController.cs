using Microsoft.AspNetCore.Mvc;
using SUM.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SUM.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        // Renders the login view page
        [HttpGet("Auth/LoginPage")]
        public IActionResult LoginPage()
        {
            return View("Login"); // Looks for Views/Auth/Login.cshtml
        }

        // API endpoint to perform login
        [HttpPost("Auth/Login")]
        public IActionResult Login([FromBody] User login)
        {
            if (login.Username == "admin" && login.Password == "1234")
            {
                var token = GenerateJwtToken(login.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            // Key must be at least 256 bits (32 bytes)
            if (key.KeySize < 256)
            {
                throw new Exception("JWT key size is too small. It must be at least 256 bits (32 bytes).");
            }

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: null,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
