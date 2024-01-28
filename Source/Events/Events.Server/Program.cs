using AspNetCore.Authentication.ApiKey;
using Events;
using Events.Server;
using Events.Server.Auth;
using Events.Server.Data.Db;
using Events.Server.Services;
using Events.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddDbContext<AuthDbContext>(e => e.UseInMemoryDatabase("Auth"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.AddSingleton<IStore, InMemoryStore>();
builder.Services.AddScoped<IAuthorizationHandler, ApiKeyAuthorizationHandler>();
// builder.Services.AddSingleton<QueueIngestService>();
// builder.Services.AddHostedService(e => e.GetRequiredService<QueueIngestService>());
builder.Services.AddScoped<UserManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = "ApiKey",
    });

    // options.AddSecurityRequirement(new OpenApiSecurityRequirement
    // {
    //     {
    //         new OpenApiSecurityScheme
    //         {
    //             Reference = new OpenApiReference
    //             {
    //                 Type=ReferenceType.SecurityScheme,
    //                 Id="Bearer"
    //             }
    //         },
    //         Array.Empty<string>()
    //     }
    // });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    policy
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin());
});
//builder.Services.AddAuthorization(option =>
//{
//    option.AddPolicy("ApiKey", policy =>
//    {
//        policy.Requirements.Add(new ApiKeyRequirement());
//    });
//});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiKey", policy =>
    {
        policy.AddAuthenticationSchemes(new[] { ApiKeyDefaults.AuthenticationScheme });
        policy.Requirements.Add(new RoleRequirements());
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "ApiKey";
    options.DefaultAuthenticateScheme = ApiKeyDefaults.AuthenticationScheme;

}).AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKey", null);

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = "Smart";
//    options.DefaultChallengeScheme = "Smart";
//})
//.AddPolicyScheme("Smart", "Authorization Bearer or Apikey", options =>
//{
//    options.ForwardDefaultSelector = context =>
//    {

//        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

//        if (authHeader?.StartsWith("Bearer ") == true)
//        {
//            return JwtBearerDefaults.AuthenticationScheme;
//        }

//        return ApiKeyDefaults.AuthenticationScheme;
//    };
//});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AuthDbContext>();

    var jsonString = await File.ReadAllTextAsync("auth.config.json");

    var authConfig = JsonSerializer.Deserialize<AuthConfig>(jsonString);
    var authDb = services.GetRequiredService<AuthDbContext>();
    var userManager = services.GetRequiredService<UserManager>();
    
    foreach(var key in authConfig.ApiKeys)
    {
        await authDb.ApiKeys.AddAsync(key);
    }
    await authDb.SaveChangesAsync();

    foreach (var user in authConfig.Users)
    {
        await authDb.Users.AddAsync(user);
    }
    await authDb.SaveChangesAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


