using AspNetCore.Authentication.ApiKey;
using Azure.Core.Pipeline;
using Events.Server.Auth.ApiKey;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
                    Scheme = "Basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header"
                });
                options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = new ApiKeyAuthenticationOptions().ApiKeyHeaderName,
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
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
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                 });
            });

            return service;
        }

        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Smart", policy =>
                {
                    policy.AddAuthenticationSchemes(new[] { ApiKeyDefaults.AuthenticationScheme, "Basic" });
                    policy.AddRequirements(new RoleRequirements());
                });
                options.AddPolicy("Bearer", policy =>
                {
                    policy.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).Build();
                });

            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Smart";
                options.DefaultChallengeScheme = "Smart";

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "Topica",
                    ValidAudience = "Topica:UI",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKey"])),
                    LogValidationExceptions = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            })
            .AddPolicyScheme("Smart", "Basic Authorization or Apikey", options =>
            {
                options.ForwardDefaultSelector = context =>
                {

                    if (context.Request.Headers[new ApiKeyAuthenticationOptions().ApiKeyHeaderName].FirstOrDefault() is not null)
                        return ApiKeyDefaults.AuthenticationScheme;

                    var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

                    if (authHeader?.StartsWith("Bearer ", StringComparison.InvariantCultureIgnoreCase) == true)
                    {
                        return JwtBearerDefaults.AuthenticationScheme;
                    }

                    if (authHeader?.StartsWith("Basic ", StringComparison.InvariantCultureIgnoreCase) == true)
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
