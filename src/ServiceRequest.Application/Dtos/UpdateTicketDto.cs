namespace ServiceRequest.Application.Dtos;

public class UpdateTicketDto
{
    public int Id { get; set; }
    public string Object { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Priority { get; set; }
    public string Status { get; set; } = "Pending";
}