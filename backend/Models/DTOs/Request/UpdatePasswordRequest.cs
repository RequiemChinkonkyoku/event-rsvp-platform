namespace Models.DTOs.Request;

public class UpdatePasswordRequest
{
    public string CurrentPassword { get; set; }
    
    public string NewPassword { get; set; }
    
    public string? UpdatedBy { get; set; }
}