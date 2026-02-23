using ServiceRequest.Application.Dtos;
using ServiceRequest.Application.Interfaces;

namespace ServiceRequest.Api.Endpoints;

public static class UsersEndpoints
{
    public static void MapUsersEndpoints(this WebApplication app)
    {
        // GET all users
        app.MapGet("/api/users", async (IUserService service) =>
        {
            var all = await service.GetAllAsync();
            return Results.Ok(all);
        });

        // GET user by id
        app.MapGet("/api/users/{id:int}", async (int id, IUserService service) =>
        {
            var item = await service.GetByIdAsync(id);
            return item == null ? Results.NotFound() : Results.Ok(item);
        });

        // POST (Create) user
        app.MapPost("/api/users", async (CreateUserDto dto, IUserService service) =>
        {
            var (ok, error, created) = await service.CreateAsync(dto);
            return ok 
                ? Results.Created($"/api/users/{created!.Id}", created) 
                : Results.BadRequest(error);
        });

        // PUT (Update) user
        app.MapPut("/api/users/{id:int}", async (int id, UpdateUserDto dto, IUserService service) =>
        {
            var (ok, error, updated) = await service.UpdateAsync(id, dto);
            return ok ? Results.Ok(updated) : Results.BadRequest(error);
        });

        // DELETE user
        app.MapDelete("/api/users/{id:int}", async (int id, IUserService service) =>
        {
            var ok = await service.DeleteAsync(id);
            return ok ? Results.NoContent() : Results.NotFound();
        });
    }
}