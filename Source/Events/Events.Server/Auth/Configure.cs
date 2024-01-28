using AspNetCore.Authentication.ApiKey;
using Events.Server.Auth.ApiKey;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Events.Server.Auth
{
    public static class Configure
    {
        public static IServiceCollection ConfigureSwaggerGen(this IServiceCollection service)
        {
            service.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = new ApiKeyAuthenticationOptions().ApiKeyHeaderName,
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic"
                            }
                        },
                        new string[] {}
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        new string[] {}
                    }
                 });
            });

            return service;
        }

        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Smart", policy =>
                {
                    policy.AddAuthenticationSchemes(new[] { ApiKeyDefaults.AuthenticationScheme,  "Basic" });
                    policy.Requirements.Add(new RoleRequirements());
                });
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Smart";
                options.DefaultChallengeScheme = "Smart";

            }).AddPolicyScheme("Smart", "Basic Authorization or Apikey", options =>
            {
                options.ForwardDefaultSelector = context =>
                {

                    var apiHeader = context.Request.Headers[new ApiKeyAuthenticationOptions().ApiKeyHeaderName].FirstOrDefault();
                    if (apiHeader is not null)
                        return ApiKeyDefaults.AuthenticationScheme;

                    var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                    if (authHeader?.StartsWith("Basic ") == true)
                    {
                        return "Basic";
                    }
                    return "Basic";
                };
            })
            .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyDefaults.AuthenticationScheme, null)
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

            return services;
        }
    }
}
