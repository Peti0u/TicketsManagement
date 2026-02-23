using Tickets.Application.dtos; 

namespace Tickets.Application.validation;

public static class TicketsValidators
{
    public static (bool IsValid, string Message) ValidateCreate(CreateTicketsDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) return (false, "Le titre est requis.");
        return (true, "");
    }

    public static (bool IsValid, string Message) ValidateUpdate(UpdateTicketsDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) return (false, "Le titre est requis.");
        return (true, "");
    }
}