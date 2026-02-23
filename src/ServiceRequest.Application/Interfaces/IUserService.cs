using ServiceRequest.Application.Dtos;

namespace ServiceRequest.Application.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task<(bool Ok, string Error, UserDto? Created)> CreateAsync(CreateUserDto dto);
    Task<(bool Ok, string Error, UserDto? Updated)> UpdateAsync(int id, UpdateUserDto dto);
    Task<bool> DeleteAsync(int id);
}