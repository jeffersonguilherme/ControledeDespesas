using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleDeDespesas.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    public DbSet<User> Users { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}