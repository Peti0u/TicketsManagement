using Microsoft.EntityFrameworkCore;
using ServiceRequest.Application.Interfaces;
using ServiceRequest.Infrastructure.Data;     
using ServiceRequest.Infrastructure.Repositories; 
using ServiceRequest.Service.Services;     
using ServiceRequest.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// --- Services ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Ajouté pour tester avec l'interface Swagger

// Configuration de la base de données SQL Server (Docker)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Injection des dépendances
builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();
builder.Services.AddScoped<ITicketsService, TicketsService>(); 

var app = builder.Build();

// --- Middleware & Routes ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// Enregistrement de tes endpoints (Minimal API)
app.MapTicketsEndpoints();

app.Run();