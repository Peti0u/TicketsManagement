namespace ServiceRequest.Application.Dtos;

public record TicketsDto(int Id, string Title, string Description, string Status);

public record CreateTicketsDto(string Title, string Description);

public record UpdateTicketsDto(string Title, string Description);