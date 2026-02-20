namespace Tickets.Application.dtos;

public record TicketDto (
    int Id,
    string Username,
    string Object,
    string Content,
    int Priority,
    int Status,
    DateTimeOffset? CreatedAt
);