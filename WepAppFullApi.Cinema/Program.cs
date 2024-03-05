using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WepAppFullApi.Cinema.Data;
using WepAppFullApi.Cinema.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlServer<CinemaDbContext>(builder.Configuration.GetConnectionString("Default"));
builder.Services.AddControllers();
builder.Services.AddSingleton<Mapper>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    CinemaDbContext ctx = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();
    ctx.Database.Migrate();
    if (!ctx.Technologies.Any())
    {
        List<TechnologyJson>? techjson = JsonSerializer.Deserialize<List<TechnologyJson>>(File.ReadAllText("Technology.json"));
        if (techjson != null)
        {
            List<Technology> toDb = techjson.Select(g => new Technology() { 
                Name = g.name,
                TechnologyType = g.type 
            }).ToList();
            ctx.Technologies.AddRange(toDb);
            ctx.SaveChanges();
        }
    }

    if (!ctx.AgeLimits.Any())
    {
        List<AgeLimitJson>? agejson = JsonSerializer.Deserialize<List<AgeLimitJson>>(File.ReadAllText("AgeLimit.json"));
        if (agejson != null)
        {
            List<AgeLimit> toDb = agejson.Select(a => new AgeLimit()
            {
                Description = a.name,
            }).ToList();
            ctx.AgeLimits.AddRange(toDb);
            ctx.SaveChanges();
        }

    }

    if (!ctx.ActivityRoles.Any())
    {
        List<ActivityRoleJson>? rolejson = JsonSerializer.Deserialize<List<ActivityRoleJson>>(File.ReadAllText("ActivityRole.json"));
        if (rolejson != null)
        {
            List<ActivityRole> toDb = rolejson.Select(g => new ActivityRole()
            {
                Description = g.name
            }).ToList();
            ctx.ActivityRoles.AddRange(toDb);
            ctx.SaveChanges();
        }
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
