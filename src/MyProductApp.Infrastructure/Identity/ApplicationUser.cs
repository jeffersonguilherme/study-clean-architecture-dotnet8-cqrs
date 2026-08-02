using Microsoft.AspNetCore.Identity;

namespace MyProductApp.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string Matricula { get; set; } = string.Empty;
}