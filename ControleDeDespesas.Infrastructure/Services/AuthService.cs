using ControleDeDespesas.Application.DTOs.Auth;
using ControleDeDespesas.Application.Interfaces;
using ControleDeDespesas.Infrastructure.Data;
using ControleDeDespesas.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ControleDeDespesas.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _db;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(UserManager<ApplicationUser> userManager,
                       SignInManager<ApplicationUser> signInManager,
                       RoleManager<IdentityRole> roleManager,
                       ApplicationDbContext db,
                       IJwtTokenGenerator jwtTokenGenerator
                       )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _db = db;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto)
    {
        var emailExists = await _userManager.FindByEmailAsync(dto.Email);
        if(emailExists != null)
            throw new InvalidOperationException("Este e-mail já estar em uso");

            var registrationInUse = await _userManager.Users.AnyAsync(u => u.Registration == dto.Registration);
        
        if(registrationInUse)
            throw new InvalidOperationException("Esta matricula já está em uso");

        var roleByRegistration = await _db.RoleByRegistrations.AsNoTracking().FirstOrDefaultAsync(x => x.Registration == dto.Registration);

        if(roleByRegistration == null)
            throw new InvalidOperationException("Matrícula não autorizada");

        var roleName = roleByRegistration.RoleName;

        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if(!roleExists)
        {
            var createRoleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if(!createRoleResult.Succeeded)
                throw new InvalidOperationException("Falha ao criar role no Identity");
        }

        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            FullName = dto.FullName,
            Registration = dto.Registration
        };

        var createUserResult = await _userManager.CreateAsync(user, dto.Password);
        if(!createUserResult.Succeeded)
        {
            var errors = string.Join(" | ", createUserResult.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"Falha ao criar usuário: {errors}");
        }

        var addToRoleResult = await _userManager.AddToRoleAsync(user, roleName);
        if (!addToRoleResult.Succeeded)
        {
            var errors = string.Join(" | ", addToRoleResult.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"Falha ao atribuir role: {errors}");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim("fullName", user.FullName),
            new Claim("registration", user.Registration),
            new Claim(ClaimTypes.Role, roleName)
        };

        var (token, expiresAtUtc) = _jwtTokenGenerator.GenerateToken(claims);

        return new AuthResponseDto
        {
            Token = token,
            ExpiresAtUtc = expiresAtUtc,
            Email = user.Email ?? "",
            FullName = user.FullName,
            Registration = user.Registration,
            Role = roleName
        };
    }
    public async Task<AuthResponseDto> LoginAsync(LoginUserDto dto)
    {
        var user  = await _userManager.FindByEmailAsync(dto.Email);
        if(user == null)
            throw new InvalidOperationException("Credenciais invalidas");

        var singInResult = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: true);
        if(!singInResult.Succeeded)
            throw new InvalidOperationException("Credenciais inválidas");

        var roles = await _userManager.GetRolesAsync(user);
        var roleName = roles.FirstOrDefault() ?? "";

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim("fullName", user.FullName),
            new Claim("registration", user.Registration),
            new Claim(ClaimTypes.Role, roleName)
        };

        var (token, expiresAtUtc) = _jwtTokenGenerator.GenerateToken(claims);

        return new AuthResponseDto
        {
            Token = token,
            ExpiresAtUtc = expiresAtUtc,
            Email = user.Email ?? "",
            FullName = user.FullName,
            Registration = user.Registration,
            Role = roleName
        };
    }

}