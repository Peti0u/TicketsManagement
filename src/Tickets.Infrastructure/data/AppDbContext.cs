using Microsoft.EntityFrameworkCore;
using TicketsApp.Domain.entities;
namespace TicketsApp.Infrastructure.data;

public class AppDbContext : DbContext {
 public AppDbContext(DbContextOptions<AppDbContext> options)
 : base(options) { }

 public DbSet<Tickets> Ticketss => Set<Tickets>();
 protected override void OnModelCreating(ModelBuilder modelBuilder) {
              base.OnModelCreating(modelBuilder);
                    modelBuilder.Entity<Tickets>(entity => {
                        entity.ToTable("Ticketss");
                        entity.HasKey(e => e.Id);
                        entity.Property(e => e.Title)
                              .IsRequired()
                              .HasMaxLength(100);
                       entity.Property(e => e.Description)
                             .IsRequired()
                             .HasMaxLength(500);
                       entity.Property(e => e.Status)
                             .IsRequired();
                       entity.Property(e => e.CreatedAt)
                             .HasDefaultValueSql("GETDATE()");
                       entity.Property(e => e.CompletedAt)
                             .IsRequired(false);
              });
    }
}