using Events.Server.Data.Db;
using Events.Server.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Events.Server.Auth.ApiKey
{

    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly PasswordHasher passwordHasher;

        public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, AuthDbContext authDbContext, PasswordHasher passwordHasher)
            : base(options, logger, encoder)
        {
            AuthDbContext = authDbContext;
            this.passwordHasher = passwordHasher;
        }

        AuthDbContext AuthDbContext { get; }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(Options.ApiKeyHeaderName, out var apiKeyValues))
            {
                return AuthenticateResult.NoResult();
            }

            var apiKey = apiKeyValues.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return AuthenticateResult.Fail("Invalid API key");
            }

            var key = await AuthDbContext.ApiKeys.FirstOrDefaultAsync(e => e.ApiKey == passwordHasher.HashPassword(apiKey));

            if (key == null)
            {
                return AuthenticateResult.Fail("Invalid API key");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "api key"),
            };

            foreach (var role in key.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var identity = new ClaimsIdentity(claims, Options.Scheme);
            var identities = new List<ClaimsIdentity> { identity };
            var principal = new ClaimsPrincipal(identities);
            var ticket = new AuthenticationTicket(principal, Options.Scheme);

            return AuthenticateResult.Success(ticket);
        }
    }

}
