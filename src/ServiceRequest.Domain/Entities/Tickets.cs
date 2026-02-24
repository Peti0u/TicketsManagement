namespace ServiceRequest.Domain.Entities; 

public class Ticket 
{
    public int Id { get; set; }
    public string Object { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Priority { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
}