using ControleDeDespesas.Domain.Models.Entities;
using ControleDeDespesas.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleDeDespesas.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<RoleByRegistration> RoleByRegistrations => Set<RoleByRegistration>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>().HasIndex(u => u.Registration).IsUnique();

        builder.Entity<ApplicationUser>().Property(u =>u.Registration).HasMaxLength(50).IsRequired();

        builder.Entity<ApplicationUser>().Property(u => u.FullName).HasMaxLength(200).IsRequired();

        builder.Entity<RoleByRegistration>().HasIndex(r => r.Registration).IsUnique();

        builder.Entity<RoleByRegistration>().Property(r => r.Registration).HasMaxLength(50).IsRequired();

        builder.Entity<RoleByRegistration>().Property(r => r.RoleName).HasMaxLength(50).IsRequired();
    }
}