using ServiceRequest.Application.Interfaces;
using ServiceRequest.Application.Dtos;
using ServiceRequest.Domain.Entities;

namespace ServiceRequest.Application.Services;

public class TicketsService : ITicketsService
{
    private readonly ITicketsRepository _repository;

    public TicketsService(ITicketsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TicketDto>> GetAllAsync()
    {
        var tickets = await _repository.GetAllAsync();
        return tickets.Select(t => new TicketDto 
        { 
            Id = t.Id, 
            Object = t.Object, 
            Content = t.Content, 
            Status = t.Status,
            Priority = t.Priority,
            UserId = t.UserId,
            CreatedAt = t.CreatedAt
        }).ToList(); 
    }

    public async Task<TicketDto?> GetByIdAsync(int id)
    {
        var t = await _repository.GetByIdAsync(id);
        if (t == null) return null;

        return new TicketDto 
        { 
            Id = t.Id, 
            Object = t.Object, 
            Content = t.Content, 
            Status = t.Status,
            Priority = t.Priority,
            UserId = t.UserId,
            CreatedAt = t.CreatedAt
        };
    }

    public async Task<TicketDto> CreateAsync(CreateTicketDto dto)
    {
        var ticket = new Ticket { 
            Object = dto.Object, 
            Content = dto.Content, 
            Priority = dto.Priority,
            UserId = dto.UserId,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(ticket);
        
        return new TicketDto 
        { 
            Id = ticket.Id, 
            Object = ticket.Object, 
            Content = ticket.Content,
            Priority = ticket.Priority,
            Status = ticket.Status,
            UserId = ticket.UserId,
            CreatedAt = ticket.CreatedAt
        };
    }

    public async Task<TicketDto?> UpdateAsync(int id, UpdateTicketDto dto)
    {
        var ticket = await _repository.GetByIdAsync(id);
        if (ticket == null) return null;

        ticket.Object = dto.Object;
        ticket.Content = dto.Content;
        ticket.Priority = dto.Priority;
        ticket.Status = dto.Status;

        await _repository.UpdateAsync(ticket);

        return new TicketDto 
        { 
            Id = ticket.Id, 
            Object = ticket.Object, 
            Content = ticket.Content, 
            Status = ticket.Status,
            Priority = ticket.Priority,
            UserId = ticket.UserId,
            CreatedAt = ticket.CreatedAt
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ticket = await _repository.GetByIdAsync(id);
        if (ticket == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}