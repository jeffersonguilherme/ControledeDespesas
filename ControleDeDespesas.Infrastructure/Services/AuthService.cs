using ControleDeDespesas.Application.DTOs.Auth;
using ControleDeDespesas.Application.Interfaces;
using ControleDeDespesas.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ControleDeDespesas.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task RegisterAsync(RegisterUserDto registerUserDto)
    {
        var user = new ApplicationUser
        {
            UserName = registerUserDto.Email,
            Email = registerUserDto.Email,
            FullName = registerUserDto.FullName,
            Cpf = registerUserDto.Cpf
        };

        var result = await _userManager.CreateAsync(user, registerUserDto.Password);
        if(!result.Succeeded)
            throw new InvalidOperationException(string.Join(", ", result.Errors.Select(e=> e.Description)));
    }
    public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);
        if (!result.Succeeded)
            throw new InvalidOperationException("Usuário ou senha inválidos.");

        return new LoginResponseDto
        {
            Token = "JWT_AQUI"
        };
    }

}