using ServiceRequest.Application.Dtos;
using ServiceRequest.Application.Interfaces;

namespace ServiceRequest.Api.Endpoints;

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

        app.MapPost("/tickets", async (CreateTicketsDto dto, ITicketsService service) =>
        {
            var (ok, error, created) = await service.CreateAsync(dto);
            return ok ? Results.Created($"/tickets/{created!.Id}", created) : Results.BadRequest(error);
        });

        app.MapPut("/tickets/{id}", async (int id, UpdateTicketsDto dto, ITicketsService service) =>
        {
            var (ok, error, updated) = await service.UpdateAsync(id, dto);
            return ok ? Results.Ok(updated) : Results.BadRequest(error);
        });

        app.MapDelete("/api/Tickets/{id:int}", async (int id, ITicketsService service) =>
        {
            var ok = await service.DeleteAsync(id);
            return ok ? Results.NoContent() : Results.NotFound();
        });
    }
}