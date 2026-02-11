namespace ControleDeDespesas.Domain.Models.Entities;

public class RoleByRegistration
{
    public Guid Id { get; set; }
    public string Registration { get; set; }= string.Empty;
    public string RoleName { get; set; } = string.Empty;
}