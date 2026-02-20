using Tickets.Application.dtos;
using Tickets.Application.interfaces;
using Tickets.Application.validation;
using Tickets.Domain.entities;
using Tickets.Domain.enums;

namespace Tickets.Service;

public class Class1 : ITicketsService
{
    private readonly ITicketsRepository _repo;

    public TicketsService(
    ITicketsRepository repo) => _repo = repo;

    public async Task<List<TicketsDto>> GetAllAsync()
    {
        var items = await _repo.GetAllAsync();
        return items.Select(ToDto).ToList();
    }

    public async Task<TicketsDto?>
    GetByIdAsync(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item == null ? null : ToDto(item);
    }

    public async Task<(bool ok, string error,
       TicketsDto? created)>
       CreateAsync(CreateTicketsDto dto)
    {
        var (ok, error) =
            TicketsValidators.Validate(dto);
        if (!ok) return (false, error, null);

        var entity = new Tickets
        {
            Title = dto.Title.Trim(),
            Description = dto.Description.Trim(),
            Status = RequestStatus.Open
        };

        var created = await _repo.AddAsync(entity);
        return (true, "", ToDto(created));
    }

    public async Task<(bool ok, string error, TicketsDto? updated)>UpdateAsync(int id, UpdateTicketsDto dto)
    {
        var (ok, error) =
        TicketsValidators.Validate(dto);
        if (!ok) return (false, error, null);

        var existing = await _repo.GetByIdAsync(id);
        if (existing == null)
            return (false, "Not found.", null);

        existing.Title = dto.Title.Trim();
        existing.Description = dto.Description.Trim();
        existing.Status = (RequestStatus)dto.Status;

        if (existing.Status == RequestStatus.Completed && existing.CompletedAt == null)
            existing.CompletedAt = DateTime.UtcNow;

        if (existing.Status != RequestStatus.Completed)
            existing.CompletedAt = null;

        var updated = await _repo.UpdateAsync(existing);
        return updated == null ? (false, "Update failed.", null) : (true, "", ToDto(updated));
    }

    public async Task<bool> DeleteAsync(int id)
       => await _repo.DeleteAsync(id);

    private static TicketsDto ToDto(Tickets e)
        => new TicketsDto(
            e.Id,
            e.Title,
            e.Description,
            (int)e.Status,
            e.CreatedAt,
            e.CompletedAt
        );
}