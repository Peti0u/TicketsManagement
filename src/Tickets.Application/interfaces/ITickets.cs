using Tickets.Application.dtos;
namespace Tickets.Application.interfaces;

public interface ITicketsService
{
    Task<List<TicketsDto>> GetAllAsync();
    Task<TicketsDto?> GetByIdAsync(int id);
    Task<(bool ok, string error,
          TicketsDto? created)>
        CreateAsync(CreateTicketsDto dto);
    Task<(bool ok, string error,
          TicketsDto? updated)>
        UpdateAsync(int id, UpdateTicketsDto dto);
    Task<bool> DeleteAsync(int id);
}

