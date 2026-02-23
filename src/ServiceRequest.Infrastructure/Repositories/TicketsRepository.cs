using Microsoft.EntityFrameworkCore;
using ServiceRequest.Application.Interfaces;
using ServiceRequest.Domain.Entities;
using ServiceRequest.Infrastructure.Data;

namespace ServiceRequest.Infrastructure.Repositories;

public class TicketsRepository : ITicketsRepository
{
    private readonly AppDbContext _context;

    // Le nom doit être EXACTEMENT celui de la classe
    public TicketsRepository(AppDbContext context) 
    {
        _context = context;
    }

    public async Task<List<Ticket>> GetAllAsync() => await _context.Tickets.ToListAsync();

    public async Task<Ticket?> GetByIdAsync(int id) => await _context.Tickets.FindAsync(id);

    public async Task<Ticket> AddAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> UpdateAsync(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task DeleteAsync(int id)
    {
        var ticket = await GetByIdAsync(id);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }
}