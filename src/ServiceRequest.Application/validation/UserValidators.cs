using ServiceRequest.Application.Dtos; 

namespace ServiceRequest.Application.validation;

public static class UserValidators
{
    public static (bool IsValid, string Message) ValidateCreate(CreateUserDto dto)
    {
        return (true, "");
    }

    public static (bool IsValid, string Message) ValidateUpdate(UpdateUserDto dto)
    {
        return (true, "");
    }
}