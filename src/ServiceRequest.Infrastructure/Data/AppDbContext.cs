using Microsoft.EntityFrameworkCore;
using ServiceRequest.Domain.Entities;

namespace ServiceRequest.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Ticket> Tickets { get; set; } 

    public DbSet<User> Users { get; set; }
}