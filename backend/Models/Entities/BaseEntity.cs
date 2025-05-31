using System.ComponentModel.DataAnnotations;

namespace Models.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public DateTime CreatedTime { get; set; }
    
    public DateTime LastUpdatedTime { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? LastUpdatedBy { get; set; }
    
    public bool IsDeleted { get; set; }
}