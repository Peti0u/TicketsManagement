namespace ServiceRequest.Application.Dtos;

public class TicketDto
{
    public int Id { get; set; }
    public string Object { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Priority { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
}