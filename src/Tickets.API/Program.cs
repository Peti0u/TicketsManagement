using Microsoft.EntityFrameworkCore;
using Tickets.Application.interfaces;
using Tickets.Infrastructure.data;
using Tickets.Infrastructure.repositories;
using Tickets.Service;
using Tickets.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseSqlServer(
 builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();
builder.Services.AddScoped<ITicketsService, TicketsService>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapTicketsEndpoints();

app.Run();