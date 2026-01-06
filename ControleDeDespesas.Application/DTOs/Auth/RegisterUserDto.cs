namespace ControleDeDespesas.Application.DTOs.Auth;

public class RegisterUserDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
}