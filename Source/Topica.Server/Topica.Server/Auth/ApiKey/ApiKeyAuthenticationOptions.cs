using Microsoft.AspNetCore.Authentication;

namespace Events.Server.Auth.ApiKey
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "ApiKey";

        public string Scheme => DefaultScheme;

        public string ApiKeyHeaderName = "X-API-KEY";
    }

}
