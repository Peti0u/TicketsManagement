using Microsoft.EntityFrameworkCore;
using Tickets.Application.interfaces; // Correction : Interfaces (majuscule)
using Tickets.Infrastructure.data;     // Correction : Data (majuscule)
using Tickets.Infrastructure.repositories; // Correction : Repositories (majuscule)
using Tickets.Service.services;        // Correction : Chemin vers ton implémentation
using Tickets.Api.endpoints;

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