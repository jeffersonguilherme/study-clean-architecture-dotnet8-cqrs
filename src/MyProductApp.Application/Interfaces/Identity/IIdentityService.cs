namespace MyProductApp.Application.Interfaces.Identity;

public interface IIdentityService
{
    Task<(bool Succeded, Guid? UserId, IEnumerable<string> Errors)> RegisterUserAsync(string email, string password, string role, CancellationToken ct = default);
}