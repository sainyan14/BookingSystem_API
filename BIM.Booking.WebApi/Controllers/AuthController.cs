using BIM.Booking.Application.DTOs.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BIM.Booking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[HttpPost("GenerateToken")]
        //public async Task<IActionResult> GenerateToken(IdentityRefreshTokenDto requestDto)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, requestDto.)
        //    };
        //}





    }
}
