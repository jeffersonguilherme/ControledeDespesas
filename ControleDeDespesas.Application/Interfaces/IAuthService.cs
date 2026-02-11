using ControleDeDespesas.Application.DTOs.Auth;

namespace ControleDeDespesas.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto);
    Task<AuthResponseDto> LoginAsync(LoginUserDto dto);
}