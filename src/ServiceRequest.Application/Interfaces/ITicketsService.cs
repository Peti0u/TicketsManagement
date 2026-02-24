using ServiceRequest.Application.Dtos;

namespace ServiceRequest.Application.Interfaces;

public interface ITicketsService
{
    Task<List<TicketDto>> GetAllAsync();
    
    Task<TicketDto?> GetByIdAsync(int id);
    
    Task<TicketDto> CreateAsync(CreateTicketDto dto);
    
    Task<TicketDto?> UpdateAsync(int id, UpdateTicketDto dto);
    
    Task<bool> DeleteAsync(int id);
}