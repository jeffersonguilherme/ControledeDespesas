using Microsoft.AspNetCore.Identity;

namespace ControleDeDespesas.Identity;

public class ApplicationUser : IdentityUser
{
    public Guid DomainUserId {get; set;}
}