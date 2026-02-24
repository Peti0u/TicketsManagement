using Microsoft.AspNetCore.Mvc; // INDISPENSABLE
using ServiceRequest.Application.Dtos;
using ServiceRequest.Application.Interfaces;

namespace ServiceRequest.Api.Endpoints;

public static class UsersEndpoints
{
    public static void MapUsersEndpoints(this WebApplication app)
    {
        // GET all users
        app.MapGet("/api/users", async ([FromServices] IUserService service) =>
        {
            var all = await service.GetAllAsync();
            return Results.Ok(all);
        });

        // GET user by id
        app.MapGet("/api/users/{id:int}", async (int id, [FromServices] IUserService service) =>
        {
            var item = await service.GetByIdAsync(id);
            return item == null ? Results.NotFound() : Results.Ok(item);
        });

        // POST (Create) user
        app.MapPost("/api/users", async (CreateUserDto dto, [FromServices] IUserService service) =>
        {
            // Correction : On suppose que ton IUserService renvoie maintenant directement l'objet
            var created = await service.CreateAsync(dto);
            // return Results.Created($"/api/users/{created.Id}", created);
        });

        // PUT (Update) user
        app.MapPut("/api/users/{id:int}", async (int id, UpdateUserDto dto, [FromServices] IUserService service) =>
        {
            var updated = await service.UpdateAsync(id, dto);
            // return updated != null ? Results.Ok(updated) : Results.NotFound();
        });

        // DELETE user
        app.MapDelete("/api/users/{id:int}", async (int id, [FromServices] IUserService service) =>
        {
            var ok = await service.DeleteAsync(id);
            return ok ? Results.NoContent() : Results.NotFound();
        });
    }
}