using AspNetCore.Authentication.ApiKey;
using Events;
using Events.Server;
using Events.Server.Auth;
using Events.Server.Auth.ApiKey;
using Events.Server.Config;
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

builder.Services.AddDbContext<AuthDbContext>(e => e.UseInMemoryDatabase("Auth"));
builder.Services.AddDbContext<ApplicationDbContext>(e =>
{
    switch (builder.Configuration["DbType"])
    {
        case "Postgres":
            e.UseNpgsql(builder.Configuration["DbConnectionString"]);
            break;
        case "SqlServer":
            e.UseSqlServer(builder.Configuration["DbConnectionString"]);
            break;
        case "Sqlite":
            e.UseSqlite(builder.Configuration["DbConnectionString"]);
            break;
        default:
            e.UseInMemoryDatabase("Data");
            break;
    }
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.AddSingleton(e => new PasswordHasher());

builder.Services.AddSingleton<IStore, InMemoryStore>();
builder.Services.AddScoped<IAuthorizationHandler, RoleAuthorizationHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwaggerGen();
builder.Services.ConfigureAuthorization();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    policy
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin());
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var jsonString = await File.ReadAllTextAsync("auth.config.json");
    var authConfig = JsonSerializer.Deserialize<AuthConfig>(jsonString) ?? throw new NullReferenceException("Invalid Auth config");

    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AuthDbContext>();

    var authDb = services.GetRequiredService<AuthDbContext>();
    var hasher = services.GetRequiredService<PasswordHasher>();

    foreach (var key in authConfig.ApiKeys)
    {
        await authDb.ApiKeys.AddAsync(new ApiKeyConfig { ApiKey = hasher.HashPassword(key.ApiKey), Roles = key.Roles });
    }

    foreach (var user in authConfig.Users)
    {
        await authDb.Users.AddAsync(
            new UserConfig
            {
                Password = hasher.HashPassword(user.Password),
                Username = user.Username,
                Roles = user.Roles
            });
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

