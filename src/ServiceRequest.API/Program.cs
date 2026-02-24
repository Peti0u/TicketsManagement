using Microsoft.EntityFrameworkCore;
using ServiceRequest.Application.Interfaces;
using ServiceRequest.Application.Services; // Corrigé : pointe vers Application.Services
using ServiceRequest.Infrastructure.Data;
using ServiceRequest.Infrastructure.Repositories;
using ServiceRequest.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// --- SERVICES ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration de la Base de données
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// --- INJECTION DE DÉPENDANCES (CORRIGÉE) ---
// Tickets
builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();
builder.Services.AddScoped<ITicketsService, TicketsService>(); // CORRECTION ICI : Interface -> Classe

// Users (Vérifie que UserService existe bien dans ton dossier Services)
builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IUserService, UserService>(); 

// --- CONFIGURATION CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// --- MIDDLEWARES ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// L'ordre est important : Routing -> Cors -> Endpoints
app.UseRouting();
app.UseCors("AllowAll");

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// --- ROUTES ---
app.MapTicketsEndpoints();
app.MapUsersEndpoints();

app.Run();