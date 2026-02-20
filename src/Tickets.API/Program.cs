using Microsoft.EntityFrameworkCore;
using Tickets.Api.Endpoints;
using Tickets.Application.Interfaces;
using Tickets.Infrastructure.Data;
using Tickets.Infrastructure.Repositories;
using Tickets.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

// DbContext — Scoped by default via AddDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseSqlServer(
 builder.Configuration
 .GetConnectionString("DefaultConnection"))
);

// DI registrations — all Scoped
builder.Services.AddScoped<ITicketsRepository,
                          TicketsRepository>();
builder.Services.AddScoped<ITicketsService,
                          TicketsService>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapTicketsEndpoints();

app.Run();