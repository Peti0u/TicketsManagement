using ServiceRequest.Application.Dtos;

namespace ServiceRequest.Application.Interfaces;

public interface ITicketsService
{
    Task<List<TicketsDto>> GetAllAsync();
    Task<TicketsDto?> GetByIdAsync(int id);
    Task<(bool Ok, string Error, TicketsDto? Created)> CreateAsync(CreateTicketsDto dto);
    Task<(bool Ok, string Error, TicketsDto? Updated)> UpdateAsync(int id, UpdateTicketsDto dto);
    Task<bool> DeleteAsync(int id);
}