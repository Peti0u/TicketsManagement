namespace Tickets.Application.dtos;

public record UpdateTicketDto (
    string Username,
    string Object,
    string Content,
    int Priority
);