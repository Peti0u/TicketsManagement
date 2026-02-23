using Microsoft.EntityFrameworkCore;
using ServiceRequest.Application.Interfaces;
using ServiceRequest.Infrastructure.Data;    
using ServiceRequest.Infrastructure.Repositories; 
using ServiceRequest.Service.Services;     
using ServiceRequest.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// --- Services ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

// Configuration de la base de données SQL Server (Docker)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// --- Injection des dépendances ---

// Repository et Service pour les Tickets
builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();
builder.Services.AddScoped<ITicketsService, TicketsService>(); 

// Repository et Service pour les Users
// IMPORTANT : L'absence de IUserRepository causait l'erreur d'exécution
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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
app.MapUsersEndpoints(); 

app.Run();