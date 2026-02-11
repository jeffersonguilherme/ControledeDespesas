using Microsoft.AspNetCore.Identity;

namespace ControleDeDespesas.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string Registration { get; set; } = string.Empty;
}