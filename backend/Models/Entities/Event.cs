namespace Models.Entities;

public class Event : BaseEntity
{
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime? StartTime { get; set; }
    
    public DateTime? EndTime { get; set; }
    
    public string? Location { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public int Capacity { get; set; }
    
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    
    public ICollection<Rsvp>? Rsvps { get; set; }
}