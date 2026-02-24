using Microsoft.AspNetCore.Mvc;
using ServiceRequest.Application.Dtos;
using ServiceRequest.Application.Interfaces;

namespace ServiceRequest.Api.Endpoints;

public static class UsersEndpoints
{
    public static void MapUsersEndpoints(this WebApplication app)
    {
        app.MapGet("/api/users", async ([FromServices] IUserService service) =>
        {
            var all = await service.GetAllAsync();
            return Results.Ok(all);
        });

        app.MapGet("/api/users/{id:int}", async (int id, [FromServices] IUserService service) =>
        {
            var item = await service.GetByIdAsync(id);
            return item == null ? Results.NotFound() : Results.Ok(item);
        });

        app.MapPost("/api/users", async (CreateUserDto dto, [FromServices] IUserService service) =>
        {
            var created = await service.CreateAsync(dto);
        });

        app.MapPut("/api/users/{id:int}", async (int id, UpdateUserDto dto, [FromServices] IUserService service) =>
        {
            var updated = await service.UpdateAsync(id, dto);
        });

        app.MapDelete("/api/users/{id:int}", async (int id, [FromServices] IUserService service) =>
        {
            var ok = await service.DeleteAsync(id);
            return ok ? Results.NoContent() : Results.NotFound();
        });
    }
}