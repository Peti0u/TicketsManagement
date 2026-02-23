namespace Tickets.Application.dtos;

public record TicketsDto(int Id, string Title, string Description, string Status);

public record CreateTicketsDto(string Title, string Description);

public record UpdateTicketsDto(string Title, string Description);