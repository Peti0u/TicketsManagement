using Tickets.Application.interfaces;
using Tickets.Application.dtos;
using Tickets.Domain.entities;

namespace Tickets.Service.services;

// 1. Assure-toi que le nom de la classe est TicketsService (pas Class1)
public class TicketsService : ITicketsService
{
    private readonly ITicketsRepository _repository;

    public TicketsService(ITicketsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TicketsDto>> GetAllAsync()
    {
        var tickets = await _repository.GetAllAsync();
        return tickets.Select(t => new TicketsDto(t.Id, t.Title, t.Description, t.Status)).ToList();
    }

    public async Task<TicketsDto?> GetByIdAsync(int id)
    {
        var t = await _repository.GetByIdAsync(id);
        return t == null ? null : new TicketsDto(t.Id, t.Title, t.Description, t.Status);
    }

    // 2. Les noms Ok, Error, Created doivent être EXACTEMENT les mêmes que dans l'interface
    public async Task<(bool Ok, string Error, TicketsDto? Created)> CreateAsync(CreateTicketsDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            return (false, "Le titre est requis", null);

        var ticket = new Ticket { Title = dto.Title, Description = dto.Description };
        await _repository.AddAsync(ticket);

        var result = new TicketsDto(ticket.Id, ticket.Title, ticket.Description, ticket.Status);
        return (true, string.Empty, result);
    }

    // 3. Idem ici : Ok, Error, Updated
    public async Task<(bool Ok, string Error, TicketsDto? Updated)> UpdateAsync(int id, UpdateTicketsDto dto)
    {
        var ticket = await _repository.GetByIdAsync(id);
        if (ticket == null) return (false, "Ticket introuvable", null);

        ticket.Title = dto.Title;
        ticket.Description = dto.Description;
        await _repository.UpdateAsync(ticket);

        var result = new TicketsDto(ticket.Id, ticket.Title, ticket.Description, ticket.Status);
        return (true, string.Empty, result);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ticket = await _repository.GetByIdAsync(id);
        if (ticket == null) return false;
        await _repository.DeleteAsync(id);
        return true;
    }
}