using Microsoft.AspNetCore.Identity;

namespace ControleDeDespesas.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
}