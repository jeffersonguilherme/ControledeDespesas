using ControleDeDespesas.Application.DTOs.Auth;

namespace ControleDeDespesas.Application.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterUserDto registerUserDto);
    Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
}