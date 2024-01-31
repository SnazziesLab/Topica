using Events.Server.Data.Db;
using Events.Server.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Events.Server.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly PasswordHasher passwordHasher;

        AuthDbContext AuthDbContext { get; }

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, AuthDbContext authDbContext, PasswordHasher passwordHasher)
            : base(options, logger, encoder)
        {
            AuthDbContext = authDbContext;
            this.passwordHasher = passwordHasher;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authKey = Request.Headers.Authorization;
            // Read the Authorization Header

            var endpoint = Context.GetEndpoint();

            if (endpoint == null)
            {
                return AuthenticateResult.NoResult();
            }

            // Check if the Authorize attribute is applied to the endpoint
            var authorizeData = endpoint.Metadata.GetOrderedMetadata<IAuthorizeData>();
            if (!authorizeData.Any())
            {
                return AuthenticateResult.NoResult();
            }

            if (string.IsNullOrEmpty(Request.Headers["Authorization"]) &&       string.IsNullOrEmpty(Request.Headers["X-API-KEY"]))
            {
                return AuthenticateResult.Fail("Missing Authorization or X-API-KEY header");
            }

            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
            var username = credentials[0];
            var password = credentials[1];

            var user = await AuthDbContext.Users.SingleOrDefaultAsync(e => e.Username == username && e.Password == passwordHasher.HashPassword(password));

            if (user is null)
                return AuthenticateResult.Fail("Invalid Username or Password");


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);


        }
    }

}
