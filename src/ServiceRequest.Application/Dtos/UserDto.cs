namespace ServiceRequest.Application.Dtos;

public record UserDto(int Id, string Title, string Description, string Status);

public record CreateUserDto(string Title, string Description);

public record UpdateUsersDto(string Title, string Description);