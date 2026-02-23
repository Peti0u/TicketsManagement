using Tickets.Application.dtos;
using Tickets.Application.interfaces;

namespace Tickets.Api.Endpoints;

public static class TicketsEndpoints
{
    public static void MapTicketsEndpoints(this WebApplication app)
    {
        app.MapGet("/api/Tickets", async (ITicketsService service) =>
        {
            var all = await service.GetAllAsync();
            return Results.Ok(all);
        });

        app.MapGet("/api/Tickets/{id:int}", async (int id, ITicketsService service) =>
        {
            var item = await service.GetByIdAsync(id);
            return item == null ? Results.NotFound() : Results.Ok(item);
        });

        app.MapPost("/api/Tickets", async (CreateTicketDto dto, ITicketsService service) =>
        {
            var (ok, error, created) = await service.CreateAsync(dto);
            if (!ok) return Results.BadRequest(new { error });
            return Results.Created($"/api/Tickets/{created!.Id}", created);
        });

        app.MapPut("/api/Tickets/{id:int}", async (int id, UpdateTicketDto dto, ITicketsService service) =>
        {
            var (ok, error, updated) = await service.UpdateAsync(id, dto);
            if (!ok)
            {
                if (error == "Not found.") return Results.NotFound();
                return Results.BadRequest(new { error });
            }
            return Results.Ok(updated);
        });

        app.MapDelete("/api/Tickets/{id:int}", async (int id, ITicketsService service) =>
        {
            var ok = await service.DeleteAsync(id);
            return ok ? Results.NoContent() : Results.NotFound();
        });
    }
}