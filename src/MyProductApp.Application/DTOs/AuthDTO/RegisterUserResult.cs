namespace MyProductApp.Application.DTOs.AuthDTO;

public class RegisterUserResult
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
}