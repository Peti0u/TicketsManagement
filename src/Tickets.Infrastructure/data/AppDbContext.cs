using Microsoft.EntityFrameworkCore;
using Tickets.Domain.entities;

namespace Tickets.Infrastructure.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // On utilise "Ticket" (classe) pour créer une table "Tickets"
    public DbSet<Ticket> Tickets { get; set; } 
}