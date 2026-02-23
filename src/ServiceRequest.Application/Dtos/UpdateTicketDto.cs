namespace ServiceRequest.Application.Dtos;

public record UpdateTicketDto (
    string Username,
    string Object,
    string Content,
    int Priority
);