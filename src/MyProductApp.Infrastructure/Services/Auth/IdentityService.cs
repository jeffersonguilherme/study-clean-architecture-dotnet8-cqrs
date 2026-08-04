using Microsoft.AspNetCore.Identity;
using MyProductApp.Application.Interfaces.Identity;
using MyProductApp.Infrastructure.Identity;

namespace MyProductApp.Infrastructure.Services.Auth;

public class IdentityService : IIdentityService
{ 
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<(bool Succeeded, Guid? UserId, IEnumerable<string> Errors)> RegisterUserAsync(string email, string password, string role, CancellationToken ct = default)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if(!result.Succeeded)
            return (false, null, result.Errors.Select(e =>e.Description));

        await _userManager.AddToRoleAsync(user, role);

        return (true, Guid.Parse(user.Id), Enumerable.Empty<string>());
    }

    public async Task<(bool Succeeded, Guid? UserId, string? Email, IEnumerable<string> Roles)> ValidateCredentialsAsync(string email, string password, CancellationToken ct = default)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if(user is null)
            return (false, null, null, Enumerable.Empty<string>());
        
        var passwordValid = await _userManager.CheckPasswordAsync(user, password);
        
        if(!passwordValid)
            return (false, null, null, Enumerable.Empty<string>());

        var roles = await _userManager.GetRolesAsync(user);

        return (true, Guid.Parse(user.Id), user.Email, roles);
    }
}