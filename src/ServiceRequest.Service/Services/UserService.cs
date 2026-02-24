using ServiceRequest.Application.Interfaces;
using ServiceRequest.Application.Dtos;
using ServiceRequest.Domain.Entities;

namespace ServiceRequest.Application.Services; 

public class UserService : IUserService
{
    private readonly IUserRepository _repository; 

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        return users.Select(u => new UserDto 
        { 
            Id = u.Id, 
            Username = u.Username,
            CreatedAt = u.CreatedAt 
        }).ToList();
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var u = await _repository.GetByIdAsync(id);
        if (u == null) return null;

        return new UserDto 
        { 
            Id = u.Id, 
            Username = u.Username,
            CreatedAt = u.CreatedAt 
        };
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto)
    {
        var user = new User 
        { 
            Username = dto.Username,
            CreatedAt = DateTime.UtcNow 
        };

        await _repository.AddAsync(user);

        return new UserDto 
        { 
            Id = user.Id, 
            Username = user.Username,
            CreatedAt = user.CreatedAt 
        };
    }

    public async Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) return null;

        user.Username = dto.Username;

        await _repository.UpdateAsync(user);

        return new UserDto 
        { 
            Id = user.Id, 
            Username = user.Username,
            CreatedAt = user.CreatedAt 
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) return false;
        
        await _repository.DeleteAsync(id);
        return true;
    }
}