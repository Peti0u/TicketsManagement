using Tickets.Domain.entities; // Cette ligne doit correspondre au namespace de ton entité

namespace Tickets.Application.interfaces;

public interface ITicketsRepository
{
    Task<List<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(int id);
    Task<Ticket> AddAsync(Ticket ticket);
    Task<Ticket> UpdateAsync(Ticket ticket);
    Task DeleteAsync(int id);
}