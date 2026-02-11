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
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterUserDto dto)
    {
        try
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }catch(InvalidOperationException ex)
        {
            return BadRequest(new {error = ex.Message});
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginUserDto dto)
    {
        try
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }catch (InvalidOperationException ex)
        {
            return Unauthorized(new {error = ex.Message});
        }
    }
}