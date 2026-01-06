using ControleDeDespesas.Application.DTOs.Auth;
using ControleDeDespesas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace ControleDeDespesas.Api.Controllers;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        await _authService.RegisterAsync(dto);
        return Ok("Usuário criado com sucesso");
    }
}