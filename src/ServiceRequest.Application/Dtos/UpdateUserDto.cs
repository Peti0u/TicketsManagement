namespace ServiceRequest.Application.Dtos;

public record UpdateUserDto (
    string Username,
    string Object,
    string Content,
    int Priority
);