using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Request;

public class CreateAccountRequest
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string FullName { get; set; }
}