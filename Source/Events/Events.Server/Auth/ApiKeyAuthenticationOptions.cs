using Microsoft.AspNetCore.Authentication;

namespace Events.Server.Auth
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "ApiKey";

        public string Scheme => DefaultScheme;

        public string ApiKeyHeaderName { get; set; } = "X-API-KEY";
    }

}
