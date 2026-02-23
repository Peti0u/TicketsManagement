using Microsoft.EntityFrameworkCore;
using ServiceRequest.Domain.Entities;

namespace ServiceRequest.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // On utilise "Ticket" (classe) pour créer une table "Tickets"
    public DbSet<Ticket> Tickets { get; set; } 
}