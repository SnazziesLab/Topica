using Events.Server.Data.Db;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.BearerToken;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Events.Server.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;
namespace Topica.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        AuthDbContext AuthDbContext { get; }
         IConfiguration Configuration { get; }

        public LoginController(AuthDbContext authDbContext, IConfiguration configuration)
        {
            AuthDbContext = authDbContext;
            Configuration = configuration;
        }

        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        [HttpPost( Name = nameof(Login))]
        public async Task<IActionResult> Login(string username, string password, 
            [FromServices] PasswordHasher passwordHasher)
        {

            var user = await AuthDbContext.Users.SingleOrDefaultAsync(e=> e.Username == username && e.Password == passwordHasher.HashPassword(password));

            if (user is null)
                return BadRequest("Invalid username or password");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecredfrsfwafawfwafwfafwfawftKey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: "Topica",
               audience: "Topica",
               claims: claims,
               expires: DateTime.Now.AddMinutes(30),
               signingCredentials: creds
           );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            Response.Headers.Add("WWW-Authenticate", $"{tokenString}");

            return Ok(new { Message = "Successfully authenticated" });
        }

    
    }
}
