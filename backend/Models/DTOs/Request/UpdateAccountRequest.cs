namespace Models.DTOs.Request;

public class UpdateAccountRequest
{
    public string? FullName { get; set; }
    
    public string? AvatarUrl { get; set; }
    
    public string? UpdatedBy { get; set; }
}