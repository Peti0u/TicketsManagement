using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

// // Connexion SQL Server
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


// --- 3. LES ENDPOINTS ---

// Message de bienvenue sur localhost:XXXX/
app.MapGet("/", () => "L'API de Gestion de Tickets est en ligne ! Rendez-vous sur /swagger pour tester.");



app.Run();