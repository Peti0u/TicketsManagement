using ServiceRequest.Domain.Entities;

namespace ServiceRequest.Application.Interfaces;

public interface ITicketsRepository
{
    Task<List<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(int id);
    Task<Ticket> AddAsync(Ticket ticket);
    Task<Ticket> UpdateAsync(Ticket ticket);
    Task DeleteAsync(int id);
}