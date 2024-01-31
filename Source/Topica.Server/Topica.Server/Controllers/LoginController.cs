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
using Microsoft.Extensions.Configuration;
namespace Topica.Server.Controllers
{
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


        public record LoginModel(string Username, string Password);

        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        [HttpPost( Name = nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginModel model, 
            [FromServices] PasswordHasher passwordHasher)
        {

            var user = await AuthDbContext.Users.SingleOrDefaultAsync(e=> e.Username == model.Username && e.Password == passwordHasher.HashPassword(model.Username));

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
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: "Topica",
               audience: "Topica:UI",
               claims: claims,
               expires: DateTime.Now.AddHours(24),
               signingCredentials: creds
           );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            Response.Headers.Add("WWW-Authenticate", $"Bearer");

            return Ok(tokenString);
        }

    
    }
}
