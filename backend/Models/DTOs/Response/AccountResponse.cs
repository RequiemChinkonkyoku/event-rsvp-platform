namespace Models.DTOs.Response;

public class AccountResponse
{
    public Guid Id { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string PasswordHash { get; set; }
    
    public string? FullName { get; set; }
    
    public string? AvatarUrl { get; set; }
}