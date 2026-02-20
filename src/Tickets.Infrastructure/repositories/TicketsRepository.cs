using Microsoft.EntityFrameworkCore;
using Tickets.Application.interfaces;
using Tickets.Domain.entities;
using Tickets.Infrastructure.data;

namespace Tickets.Infrastructure.Repositories;

public class Class1 : ITicketsRepository
{
    private readonly AppDbContext _db;
    public TicketsRepository(AppDbContext db) => _db = db;
    public async Task<List<Tickets>> GetAllAsync()
           => await _db.Ticketss
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();
    public async Task<Tickets?> GetByIdAsync(int id)
           => await _db.Ticketss.FindAsync(id);

    public async Task<Tickets> AddAsync(Tickets request)
    {
        _db.Ticketss.Add(request);
        await _db.SaveChangesAsync();
        return request;
    }

    public async Task<Tickets?> UpdateAsync(
       Tickets request)
    {
        var existing = await _db.Ticketss
                      .FindAsync(request.Id);
        if (existing == null) return null;
        existing.Title = request.Title;
        existing.Description = request.Description;
        existing.Status = request.Status;
        existing.CompletedAt = request.CompletedAt;
        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.Ticketss
            .FindAsync(id);
        if (existing == null) return false;
        _db.Ticketss.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}