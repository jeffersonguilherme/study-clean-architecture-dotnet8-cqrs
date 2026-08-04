namespace MyProductApp.Application.Interfaces.Identity;

public interface ITokenService
{
    string GenerateToken(Guid userId, string email, IEnumerable<string> roles);
}