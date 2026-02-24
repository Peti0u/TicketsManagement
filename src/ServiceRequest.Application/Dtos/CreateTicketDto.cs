namespace ServiceRequest.Application.Dtos;

public class CreateTicketDto
{
    public string Object { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Priority { get; set; }
    public int UserId { get; set; }
}