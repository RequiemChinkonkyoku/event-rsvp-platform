using Models.Constants;

namespace Models.Entities;

public class Rsvp : BaseEntity
{
    public Guid? AccountId { get; set; }
    public Account Account { get; set; }
    
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    
    public RsvpStatusEnum Status { get; set; }
    
    public string? Notes { get; set; }
}