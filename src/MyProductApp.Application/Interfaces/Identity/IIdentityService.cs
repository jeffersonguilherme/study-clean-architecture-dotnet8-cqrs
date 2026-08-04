namespace MyProductApp.Application.Interfaces.Identity;

public interface IIdentityService
{
    Task<(bool Succeeded, Guid? UserId, IEnumerable<string> Errors)> RegisterUserAsync(string email, string password, string role, CancellationToken ct = default);
    Task<(bool Succeeded, Guid? UserId, string? Email, IEnumerable<string> Roles)> ValidateCredentialsAsync(string email, string password, CancellationToken ct =default);
}