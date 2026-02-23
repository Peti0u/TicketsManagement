using ServiceRequest.Application.Interfaces;
using ServiceRequest.Application.Dtos;
using ServiceRequest.Domain.Entities;

namespace ServiceRequest.Service.Services;

// 1. Assure-toi que le nom de la classe est UserService (pas Class1)
public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var User = await _repository.GetAllAsync();
        return User.Select(t => new UserDto(t.Id, t.Title, t.Description, t.Status)).ToList();
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var t = await _repository.GetByIdAsync(id);
        return t == null ? null : new UserDto(t.Id, t.Title, t.Description, t.Status);
    }

    // 2. Les noms Ok, Error, Created doivent être EXACTEMENT les mêmes que dans l'interface
    public async Task<(bool Ok, string Error, UserDto? Created)> CreateAsync(CreateUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Username))
            return (false, "Le titre est requis", null);

        var User = new User { Title = dto.Username, Description = dto.Username };
        await _repository.AddAsync(User);

        var result = new UserDto(User.Id, User.Title, User.Description, User.Status);
        return (true, string.Empty, result);
    }

    // 3. Idem ici : Ok, Error, Updated
    public async Task<(bool Ok, string Error, UserDto? Updated)> UpdateAsync(int id, UpdateUserDto dto)
    {
        var User = await _repository.GetByIdAsync(id);
        if (User == null) return (false, "User introuvable", null);

        User.Title = dto.Username;
        User.Description = dto.Username;
        await _repository.UpdateAsync(User);

        var result = new UserDto(User.Id, User.Title, User.Description, User.Status);
        return (true, string.Empty, result);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var User = await _repository.GetByIdAsync(id);
        if (User == null) return false;
        await _repository.DeleteAsync(id);
        return true;
    }
}