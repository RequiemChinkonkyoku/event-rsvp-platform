using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Models.Entities;

public class Account : BaseEntity
{
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string PasswordHash { get; set; }
    
    public string? FullName { get; set; }
    
    public string? AvatarUrl { get; set; }
    
    public ICollection<Rsvp>? Rsvps { get; set; }
    
    public ICollection<Event>? Events { get; set; }
}