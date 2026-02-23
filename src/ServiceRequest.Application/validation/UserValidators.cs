using ServiceRequest.Application.Dtos; 

namespace ServiceRequest.Application.validation;

public static class UserValidators
{
    public static (bool IsValid, string Message) ValidateCreate(CreateUserDto dto)
    {
        // if (string.IsNullOrEmpty(dto.Title)) return (false, "Le titre est requis.");
        return (true, "");
    }

    public static (bool IsValid, string Message) ValidateUpdate(UpdateUserDto dto)
    {
        // if (string.IsNullOrEmpty(dto.Title)) return (false, "Le titre est requis.");
        return (true, "");
    }
}