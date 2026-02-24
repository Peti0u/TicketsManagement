using Microsoft.AspNetCore.Mvc; // INDISPENSABLE pour [FromServices]
using ServiceRequest.Application.Dtos;
using ServiceRequest.Application.Interfaces;

namespace ServiceRequest.Api.Endpoints;

public static class TicketsEndpoints
{
    public static void MapTicketsEndpoints(this WebApplication app)
    {
        // GET ALL
        app.MapGet("/api/Tickets", async ([FromServices] ITicketsService service) =>
        {
            var all = await service.GetAllAsync();
            return Results.Ok(all);
        });

        // GET BY ID
        app.MapGet("/api/Tickets/{id:int}", async (int id, [FromServices] ITicketsService service) =>
        {
            var item = await service.GetByIdAsync(id);
            return item == null ? Results.NotFound() : Results.Ok(item);
        });

        // POST (Création)
        app.MapPost("/api/Tickets", async (CreateTicketDto dto, [FromServices] ITicketsService service) =>
        {
            // Correction : ton service renvoie directement le TicketDto, plus de tuple
            var created = await service.CreateAsync(dto);
            return Results.Created($"/api/Tickets/{created.Id}", created);
        });

        // PUT (Modification)
        app.MapPut("/api/Tickets/{id:int}", async (int id, UpdateTicketDto dto, [FromServices] ITicketsService service) =>
        {
            // Correction : ton service renvoie l'objet mis à jour ou null
            var updated = await service.UpdateAsync(id, dto);
            return updated != null ? Results.Ok(updated) : Results.NotFound();
        });

        // DELETE
        app.MapDelete("/api/Tickets/{id:int}", async (int id, [FromServices] ITicketsService service) =>
        {
            var ok = await service.DeleteAsync(id);
            return ok ? Results.NoContent() : Results.NotFound();
        });
    }
}