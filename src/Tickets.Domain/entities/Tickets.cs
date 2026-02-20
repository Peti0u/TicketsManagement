using Tickets.Domain.enums;
namespace Tickets.Domain.entities;
public class Tickets
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public RequestStatus Status { get; set; }
    public DateTimeOffset?  CreatedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
}
