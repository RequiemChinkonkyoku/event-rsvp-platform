using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Request;

public class CreateAccountRequest
{
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string Username { get; set; }
    
    public string FullName { get; set; }
}